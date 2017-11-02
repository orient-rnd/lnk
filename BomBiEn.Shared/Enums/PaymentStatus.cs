using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// Payment status
    /// </summary>
    public enum PaymentStatus
    {
        /// <summary>
        /// New
        /// </summary>
        [Description("New")]
        New = 0,

        /// <summary>
        /// Pending
        /// </summary>
        [Description("Pending")]
        Pending = 1,

        /// <summary>
        /// Paid
        /// </summary>
        [Description("Paid")]
        Paid = 2,

        /// <summary>
        /// Cancelled
        /// </summary>
        [Description("Cancelled")]
        Cancelled = 3,

        /// <summary>
        /// Refunded
        /// </summary>
        [Description("Refunded")]
        Refunded = 4,

        /// <summary>
        /// Failed
        /// </summary>
        [Description("Failed")]
        Failed = 5
    }
}