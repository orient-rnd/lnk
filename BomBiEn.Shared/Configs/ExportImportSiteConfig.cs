using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Configs
{
    /// <summary>
    /// Define the Export Import Site config.
    /// </summary>
    public class ExportImportSiteConfig
    {
        /// <summary>
        /// Gets or sets the temporary folder.
        /// </summary>
        public string TemporaryFolder { get; set; }

        /// <summary>
        /// Gets or sets the assets folder.
        /// </summary>
        public string AssetsFolder { get; set; }

        /// <summary>
        /// Gets or sets the pages folder.
        /// </summary>
        public string PagesFolder { get; set; }

        /// <summary>
        /// Gets or sets the packages blob container.
        /// </summary>
        public string PackagesBlobContainer { get; set; }
    }
}