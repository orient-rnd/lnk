using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Configs
{
    /// <summary>
    /// Define the Redis config.
    /// </summary>
    public class RedisConfig
    {
        /// <summary>
        /// Gets or sets the redis cache connection string.
        /// </summary>
        public string RedisCacheConnectionString { get; set; }
    }
}