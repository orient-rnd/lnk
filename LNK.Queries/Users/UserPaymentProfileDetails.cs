using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Queries.Users
{
    public class UserPaymentProfileDetails
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