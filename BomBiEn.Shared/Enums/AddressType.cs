using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// Address type
    /// </summary>
    public enum AddressType
    {
        /// <summary>
        /// Shipping address
        /// </summary>
        [Description("Shipping address")] ShippingAddress = 0,

        /// <summary>
        /// Billing address
        /// </summary>
        [Description("Billing address")] BillingAddress = 1
    }
}