using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Configs
{
    /// <summary>
    /// Define the MongoDB config.
    /// </summary>
    public class MongoDbConfig
    {
        /// <summary>
        /// Gets or sets the default read connection string.
        /// Read data from the closest data center.
        /// </summary>
        public string DefaultReadConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the default write connection string.
        /// Write data to data center in Europe and sync data to all the other data centers.
        /// </summary>
        public string DefaultWriteConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the default logs connection string.
        /// </summary>
        public string DefaultLogsConnectionString { get; set; }
    }
}