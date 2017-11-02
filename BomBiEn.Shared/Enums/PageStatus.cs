using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// Page status
    /// </summary>
    public enum PageStatus
    {
        /// <summary>
        /// Draft
        /// </summary>
        [Description("Draft")]
        Draft = 0,

        /// <summary>
        /// Published
        /// </summary>
        [Description("Published")]
        Published = 1
    }
}