using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BomBiEn.Infrastructure.Queries;

namespace BomBiEn.Queries.Users
{
    public class UserPaymentProfileOverview : AuditableEntityOverviewBase
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string PaymentProvider { get; set; }

        public string PaymentMethodId { get; set; }

        public string BankId { get; set; }

        public string BankName { get; set; }

        public string LastFourDigits { get; set; }

        public string ExpiryDate { get; set; }

        public bool IsCreditCard { get; set; }

        public bool IsDefault { get; set; }
    }
}
