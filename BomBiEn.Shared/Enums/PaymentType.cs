using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// Payment type
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        /// Manually
        /// </summary>
        [Description("Manually")]
        Manually = 0,

        /// <summary>
        /// Automatically
        /// </summary>
        [Description("Automatically")]
        Automatically = 1
    }
}