using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BomBiEn.Infrastructure.Utilities
{
    public static class IOUtility
    {
        public static void CreateDirectoriesIfNotExist(string[] directoryPaths)
        {
            foreach (string directoryPath in directoryPaths)
            {
                CreateDirectoryIfNotExist(directoryPath);
            }
        }

        public static void CreateDirectoryIfNotExist(params string[] directoryPaths)
        {
            string directoryPath = Path.Combine(directoryPaths);
            bool exists = Directory.Exists(directoryPath);
            if (!exists)
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public static void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                Directory.Delete(directoryPath, true);
            }
        }

        public static Stream GetStreamOfFile(string filePath)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                fileStream.CopyTo(memoryStream);
            }
            memoryStream.Position = 0;
            return memoryStream;
        }

        public static void WriteToJsonFile(string path, string name, string jsonContent)
        {
            File.WriteAllText(String.Format(@"{0}\{1}.json", path, name), jsonContent);
        }

        public static TModel GetObjectFromJsonFile<TModel>(string filePath)
        {
            using (StreamReader stremReader = File.OpenText(filePath))
            {
                string jsonContent = stremReader.ReadToEnd();
                return JsonConvert.DeserializeObject<TModel>(jsonContent);
            }
        }

        public static TModel GetObjectFromJsonString<TModel>(string jsonContent)
        {           
            return JsonConvert.DeserializeObject<TModel>(jsonContent);            
        }
    }
}