using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="decimal"/>.
    /// </summary>
    public static class DecimalExtensions
    {
        public static Dictionary<string, string> Currencies = new Dictionary<string, string>()
        {
            {"EUR", "€"},
            {"GBP", "£"},
            {"USD", "$"}
        };

        public static string GetCurrencySymbol(string code)
        {
            if (Currencies.ContainsKey(code))
            {
                return Currencies[code];
            }
            else
            {
                return code;
            }
        }

        public static string FormatCurrency(this decimal value, string currency)
        {
            string result = String.Format("{0} {1:N2}", GetCurrencySymbol(currency), value)
                .Replace('.', '/')
                .Replace(',', '.')
                .Replace('/', ',');
            return result.Replace(",00", ",-");
        }

        public static decimal FormatPrice(this decimal value)
        {
            return decimal.Truncate(value * 100) / 100;
        }
    }
}