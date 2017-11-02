using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Constants
{
    public class PaymentMethodNames
    {
        public const string AdyenMasterCard= "Adyen.MasterCard";

        public const string AdyenVisa = "Adyen.Visa";

        public const string AdyenAmericanExpress = "Adyen.AmericanExpress";

        public const string AdyeniDeal = "Adyen.iDEAL";

        public const string BuckarooAmericanExpress = "Buckaroo.AmericanExpress";
        public const string BuckarooVisa = "Buckaroo.Visa";
        public const string BuckarooMasterCard = "Buckaroo.MasterCard";

        public static bool IsCreditCard(string paymentMethodId)
        {
            switch (paymentMethodId)
            {
                case AdyenMasterCard:
                case AdyenVisa:
                case AdyenAmericanExpress:
                case BuckarooAmericanExpress:
                case BuckarooVisa:
                case BuckarooMasterCard:
                    return true;
            }

            return false;
        }

        public static string GetMethodCode(string paymentMethodId)
        {
            string switchCase = "";
            if (paymentMethodId.Equals(AdyenMasterCard, StringComparison.OrdinalIgnoreCase))
            {
                switchCase = AdyenMasterCard;
            }
            else if (paymentMethodId.Equals(AdyenVisa, StringComparison.OrdinalIgnoreCase))
            {
                switchCase = AdyenVisa;
            }
            else if (paymentMethodId.Equals(AdyenAmericanExpress, StringComparison.OrdinalIgnoreCase))
            {
                switchCase = AdyenAmericanExpress;
            }
            else if (paymentMethodId.Equals(AdyeniDeal, StringComparison.OrdinalIgnoreCase))
            {
                switchCase = AdyeniDeal;
            }
            else
            {
                return switchCase;
            }

            switch (switchCase)
            {
                case AdyenMasterCard:
                    return "mc";
                case AdyenVisa:
                    return "visa";
                case AdyenAmericanExpress:
                    return "amex";
                case AdyeniDeal:
                    return "ideal";
                default:
                    return "";
            }
        }
    }
}
