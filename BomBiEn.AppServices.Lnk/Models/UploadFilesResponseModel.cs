using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.AppServices.Lnk.Models
{
    public class UploadFilesResponseModel
    {
        /// <summary>
        /// Base url
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Paths
        /// </summary>
        public string[] Paths { get; set; }
    }
}