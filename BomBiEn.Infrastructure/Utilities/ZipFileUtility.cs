using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Utilities
{
    public static class ZipFileUtility
    {
        public static void ZipFromDirectory(string sourceDirectoryPath, string destinationArchiveFileName)
        {
            if (!File.Exists(destinationArchiveFileName))
            {
                ZipFile.CreateFromDirectory(sourceDirectoryPath, destinationArchiveFileName, CompressionLevel.Fastest, false);
            }
        }

        public static void ExtractToDirectory(string sourceArchiveFileName, string destinationDirectoryName)
        {
            if (File.Exists(sourceArchiveFileName))
            {
                if (!Directory.Exists(destinationDirectoryName))
                {
                    Directory.CreateDirectory(destinationDirectoryName);
                }

                ZipFile.ExtractToDirectory(sourceArchiveFileName, destinationDirectoryName);
            }
        }
    }
}