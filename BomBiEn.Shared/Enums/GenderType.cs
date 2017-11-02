using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// Gender type
    /// </summary>
    public enum GenderType
    {
        /// <summary>
        /// Unknown
        /// </summary>
        [Description("Unknown")]
        Unknown = 0,

        /// <summary>
        /// Female
        /// </summary>
        [Description("Female")]
        Female = 1,

        /// <summary>
        /// Male
        /// </summary>
        [Description("Male")]
        Male = 2
    }
}