using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Configs
{
    /// <summary>
    /// Define the Azure config.
    /// </summary>
    public class AzureConfig
    {
        /// <summary>
        /// Gets or sets the Azure blob endpoint.
        /// </summary>
        public string AzureBlobEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the Azure storage connection string.
        /// </summary>
        public string AzureStorageConnectionString { get; set; }
    }
}