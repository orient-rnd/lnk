using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// Order status
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// New
        /// </summary>
        [Description("New")] New = 0,

        /// <summary>
        /// Pending
        /// </summary>
        [Description("Pending")] Pending = 1,

        /// <summary>
        /// Processing
        /// </summary>
        [Description("Processing")] Processing = 2,

        /// <summary>
        /// Completed
        /// </summary>
        [Description("Completed")] Completed = 3,

        /// <summary>
        /// Cancelled
        /// </summary>
        [Description("Cancelled")] Cancelled = 4,

        /// <summary>
        /// Failed
        /// </summary>
        [Description("Failed")] Failed = 5
    }
}