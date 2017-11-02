using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BomBiEn.Infrastructure.Azure.Blobs
{
    public interface IAzureBlobProvider
    {
        string GetBlobEndpoint();

        Task<List<IListBlobItem>> ListBlobsAsync(string prefix);

        Task DownloadBlobAsync(string containerName, string blobName, string destinationDirectoryPath);

        void DownloadBlobs(List<IListBlobItem> blobs, string destinationDirectoryPath);

        void DownloadBlobs(List<IListBlobItem> blobs, string destinationDirectoryPath, string deletedSegmentPath);

        Task UploadBlobs(List<string> listOfFileName, string localPath, string containerName, string subFolder);

        Task<Uri> CreateBlobAsync(string containerName, string blobName, Stream blobStream);
    }
}