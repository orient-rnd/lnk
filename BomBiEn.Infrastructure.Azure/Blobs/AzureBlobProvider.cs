using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BomBiEn.Infrastructure.Azure.Blobs
{
    public class AzureBlobProvider : IAzureBlobProvider
    {
        private readonly CloudStorageAccount _blobStorageAccount;
        private readonly CloudBlobClient _blobClient;

        public AzureBlobProvider(string azureStorageConnectionString)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(azureStorageConnectionString));

            _blobStorageAccount = CloudStorageAccount.Parse(azureStorageConnectionString);
            _blobClient = _blobStorageAccount.CreateCloudBlobClient();
        }

        public async Task<List<IListBlobItem>> ListBlobsAsync(string prefix)
        {
            CloudBlobClient blobClient = _blobStorageAccount.CreateCloudBlobClient();
            BlobContinuationToken continuationToken = null;

            List<IListBlobItem> results = new List<IListBlobItem>();
            do
            {
                var response = await blobClient.ListBlobsSegmentedAsync(prefix, true, BlobListingDetails.All, null, continuationToken, new BlobRequestOptions(), new OperationContext());
                continuationToken = response.ContinuationToken;
                results.AddRange(response.Results);
            }
            while (continuationToken != null);
            return results;
        }

        public string GetBlobEndpoint()
        {
            return _blobStorageAccount.BlobEndpoint.ToString().TrimEnd('/');
        }

        public async Task DownloadBlobAsync(string containerName, string fileName, string destFolder)
        {
            CloudBlockBlob blob = this.GetBlobFile(containerName, fileName);
            var blobExist = await blob.ExistsAsync();

            if (!System.IO.Directory.Exists(destFolder))
            {
                System.IO.Directory.CreateDirectory(destFolder);
            }
            if (blobExist)
            {
                using (var fileStream = System.IO.File.OpenWrite($"{destFolder}\\{Path.GetFileName(fileName)}"))
                {
                    await blob.DownloadToStreamAsync(fileStream);
                }
            }
        }

        public void DownloadBlobs(List<IListBlobItem> listOfFiles, string destFolder, string deletedSegmentPath)
        {
            Task[] tasks = new Task[listOfFiles.Count];
            foreach (var item in listOfFiles)
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;

                    var fileName = blob.Name.Replace("/", "\\");
                    var path = string.Format("{0}{1}", destFolder,
                        Path.GetDirectoryName(blob.Name).Replace(deletedSegmentPath.ToLower(), String.Empty));
                    tasks[listOfFiles.IndexOf(item)] =
                        Task.Run(
                            () =>
                                    DownloadBlobAsync(blob.Container.Name, fileName, path));
                }
            }
            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }

        public void DownloadBlobs(List<IListBlobItem> listOfFiles, string destFolder)
        {
            Task[] tasks = new Task[listOfFiles.Count];
            foreach (var item in listOfFiles)
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;

                    var fileName = blob.Name.Replace("/", "\\");
                    var path = Path.Combine(destFolder, Path.GetDirectoryName(blob.Name));
                    tasks[listOfFiles.IndexOf(item)] =
                        Task.Run(
                            () =>
                                    DownloadBlobAsync(blob.Container.Name, fileName, path));
                }
            }
            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }

        private CloudBlockBlob GetBlobFile(string containerName, string fileName)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(containerName));
            Contract.Requires(!string.IsNullOrWhiteSpace(fileName));
            CloudBlobContainer blobContainer = _blobClient.GetContainerReference(containerName);
            return blobContainer.GetBlockBlobReference(fileName);
        }

        public async Task UploadBlobs(List<string> listOfFileName, string localPath, string containerName, string subFolder)
        {
            foreach (var item in listOfFileName)
            {
                using (FileStream fileStream = System.IO.File.OpenRead(String.Format("{0}{1}", localPath, item)))
                {
                    await CreateBlobAsync(containerName, String.Format("\\{0}{1}", subFolder, item), fileStream);
                }
            }
        }

        public async Task<Uri> CreateBlobAsync(string containerName, string blobName, Stream blobStream)
        {
            containerName = EncodeContainerName(containerName);
            blobName = EncodeBlobName(blobName);

            CloudBlobContainer blobContainer = _blobClient.GetContainerReference(containerName);
            if (await blobContainer.CreateIfNotExistsAsync())
            {
                await blobContainer.SetPermissionsAsync(
                    new BlobContainerPermissions()
                    {
                        PublicAccess = BlobContainerPublicAccessType.Container
                    });
            }

            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(blobName);
            blob.Properties.ContentType = MimeKit.MimeTypes.GetMimeType(blobName);
            await blob.UploadFromStreamAsync(blobStream);

            return blob.Uri;
        }

        /// <summary>
        /// A container name must be a valid DNS name, conforming to the following naming rules:
        /// 1. Container names must start with a letter or number, and can contain only letters, numbers, and the dash(-) character.
        /// 2. Every dash(-) character must be immediately preceded and followed by a letter or number; consecutive dashes are not permitted in container names.
        /// 3. All letters in a container name must be lowercase.
        /// 4. Container names must be from 3 through 63 characters long.
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        private static string EncodeContainerName(string containerName)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(containerName));
            Contract.Requires(containerName.Length < 3 || containerName.Length > 63, "A container name must be from 3 through 63 characters long.");

            containerName = containerName.ToLower();

            Regex regex = new Regex(@"[^a-z0-9]", RegexOptions.Compiled);
            containerName = regex.Replace(containerName, "-");

            regex = new Regex(@"[-]{2,}", RegexOptions.Compiled);
            containerName = regex.Replace(containerName, "-");
            containerName = containerName.Trim('-');

            return containerName;
        }

        /// <summary>
        /// A blob name must conforming to the following naming rules:
        /// 1. A blob name can contain any combination of characters.
        /// 2. A blob name must be at least one character long and cannot be more than 1,024 characters long.
        /// 3. Blob names are case-sensitive.
        /// 4. Reserved URL characters must be properly escaped.
        /// 5. The number of path segments comprising the blob name cannot exceed 254. A path segment is the string between consecutive delimiter characters(e.g., the forward slash '/') that corresponds to the name of a virtual directory.        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        private static string EncodeBlobName(string blobName)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(blobName));

            blobName = blobName.ToLower();
            blobName = blobName.Replace("\"", String.Empty).Trim('/', '\\');

            return blobName;
        }

        public async Task UploadBlobsFromLocalToAzureBlob(List<string> listOfFileName, string localPath, string containerName)
        {
            foreach (var item in listOfFileName)
            {
                using (FileStream fileStream = System.IO.File.OpenRead(String.Format("{0}{1}", localPath, item)))
                {
                    await CreateBlobAsync(containerName, item, fileStream);
                }
            }
        }
    }
}