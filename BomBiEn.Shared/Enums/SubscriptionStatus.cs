using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// Subscription status
    /// </summary>
    public enum SubscriptionStatus
    {
        /// <summary>
        /// Inactive
        /// </summary>
        [Description("Inactive")]
        Inactive = 0,

        /// <summary>
        /// Active
        /// </summary>
        [Description("Active")]
        Active = 1,

        /// <summary>
        /// Cancelled
        /// </summary>
        [Description("Cancelled")]
        Cancelled = 2
    }
}