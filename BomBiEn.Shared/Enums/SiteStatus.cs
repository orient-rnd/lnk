using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// Site status
    /// </summary>
    public enum SiteStatus
    {
        /// <summary>
        /// Offline
        /// </summary>
        [Description("Offline")]
        Offline = 0,

        /// <summary>
        /// Online
        /// </summary>
        [Description("Online")]
        Online = 1
    }
}