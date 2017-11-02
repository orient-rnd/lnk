using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    public enum OrderSourceType
    {
        /// <summary>
        /// Default
        /// </summary>
        [Description("Default")]
        Default = 0,

        /// <summary>
        /// Subscription sign up
        /// </summary>
        [Description("Subscription sign up")]
        SubscriptionSignUp = 1,

        /// <summary>
        /// Upgrade subscription
        /// </summary>
        [Description("Upgrade subscription")]
        UpgradeSubscription = 2,

        /// <summary>
        /// Renew subscription
        /// </summary>
        [Description("Renew subscription")]
        RenewSubscription = 3
    }
}