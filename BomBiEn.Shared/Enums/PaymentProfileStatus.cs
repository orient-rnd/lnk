using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Enums
{
    public enum PaymentProfileStatus
    {
        UnVerified,
        Valid,
        Invalid,
        SuitableForRetryingPayment
    }
}
