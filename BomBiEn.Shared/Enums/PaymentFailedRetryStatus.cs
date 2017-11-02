using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public enum PaymentFailedRetryStatus
    {
        /// <summary>
        /// Can't retry
        /// </summary>
        None,

        /// <summary>
        /// Payment failed but suitable for retrying payment
        /// </summary>
        SuitableForRetrying,

        /// <summary>
        /// Waiting for new payment details to retry.
        /// </summary>
        WaitingForNewPaymentDetails,

        /// <summary>
        /// The technical failure, can't retry.
        /// </summary>
        TechnicalFailure
    }
}
