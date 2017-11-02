using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Shared.Constants
{
    public static class StoreSettingNames
    {
        /// <summary>
        /// Adyen allowed payment methods
        /// </summary>
        /// <example>iDEAL, MasterCard, Visa, AmericanExpress, Paypal</example>
        public const string AdyenAllowedPaymentMethods = "Adyen_AllowedPaymentMethods";

        /// <summary>
        /// Adyen hosted payment page url
        /// </summary>
        /// <example>https://test.adyen.com/hpp/details.shtml</example>
        public const string AdyenHostedPaymentPageUrl = "Adyen_HostedPaymentPageUrl";

        /// <summary>
        /// Adyen directory lookup url
        /// You may choose to host the payment selection on your website and skip the HPP part (directory lookup). Directory lookup enables you to directly show the entry fields for the selected payment methods to shoppers. It sends information such as the shopper location, shopping basket value and currency to the Adyen Payment Platform, which dynamically provides the list of the most relevant payment methods for this shopper to the merchant. By using this payment data, you can dynamically generate a customized payment page allowing the shopper to complete their purchase using a targeted selection of payment methods.  By selecting a payment method, the shopper is redirected to the local payment method check out of his choice, for example the shopper’s own bank iDEAL page, the shopper's own bank Suomen Verkumaksut page, PayPal page, etc. Following any payment request, Adyen sends back a notification providing the status of the payment and updates the status as soon as it changes. This means that our customers receive information about the status of the request in all cases.
        /// </summary>
        /// <example>https://test.adyen.com/hpp/directory.shtml</example>
        public const string AdyenDirectoryLookupUrl = "Adyen_DirectoryLookupUrl";

        /// <summary>
        /// Adyen merchant account
        /// The merchant account identifier you want to process the (transaction) request with.
        /// </summary>
        /// <example>EllyschoiceNL</example>
        public const string AdyenMerchantAccount = "Adyen_MerchantAccount";

        /// <summary>
        /// Adyen skin code
        /// The code of the Skin used to process the payment.
        /// </summary>
        /// <example>1MAOam7Z</example>
        public const string AdyenSkinCode = "Adyen_SkinCode";

        /// <summary>
        /// Adyen HMAC key
        /// Specify the HMAC Key for each environment, the key is used to compute the merchant signature. The same Key cannot be used for both the TEST and LIVE environments.
        /// </summary>
        /// <example>ECRB2ELLY</example>
        public const string AdyenHmacKey = "Adyen_HmacKey";

        /// <summary>
        /// Adyen API url
        /// </summary>
        /// <example>https://pal-test.adyen.com/pal/adapter/httppost</example>

        public static string AdyenApiUrl = "Adyen_ApiUrl";

        /// <summary>
        /// Adyen Recurring API url
        /// </summary>
        /// <example>https://pal-test.adyen.com/pal/servlet/Recurring/v18/</example>
        public static string AdyenApiRecurringUrl = "Adyen_ApiRecurringUrl";

        /// <summary>
        /// Adyen API user
        /// </summary>
        /// <example>ws@Company.Ellyschoice</example>

        public static string AdyenApiUser = "Adyen_ApiUser";

        /// <summary>
        /// Adyen API password
        /// </summary>
        /// <example>LH]6SPY9!\y/c-y(ZSGcPfEcx</example>
        public static string AdyenApiPassword = "Adyen_ApiPassword";
    }
}