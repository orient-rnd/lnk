using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.AppServices.Lnk.Models
{
    /// <summary>
    /// Upload files request model
    /// </summary>
    public class UploadFilesRequestModel
    {
        /// <summary>
        /// Container name
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// Directory path
        /// </summary>
        public string DirectoryPath { get; set; }
    }
}