using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// Redirect type
    /// </summary>
    public enum RedirectType
    {
        /// <summary>
        /// Permanently
        /// </summary>
        [Description("Permanently")]
        Permanently = 302,

        /// <summary>
        /// Temporarily
        /// </summary>
        [Description("Temporarily")]
        Temporarily = 301
    }
}