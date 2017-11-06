using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Utilities
{
    public static class UrlUtility
    {
        /// <summary>
        /// Parse a query string into its component key and value parts.
        /// </summary>
        /// <param name="queryString">The raw query string value, with or without the leading '?'.</param>
        /// <returns>A collection of parsed keys and values.</returns>
        public static Dictionary<string, StringValues> ParseQueryString(string queryString)
        {
            var result = ParseNullableQueryString(queryString);

            if (result == null)
            {
                return new Dictionary<string, StringValues>();
            }

            return result;
        }


        /// <summary>
        /// Parse a query string into its component key and value parts.
        /// </summary>
        /// <param name="queryString">The raw query string value, with or without the leading '?'.</param>
        /// <returns>A collection of parsed keys and values, null if there are no entries.</returns>
        public static Dictionary<string, StringValues> ParseNullableQueryString(string queryString)
        {
            var accumulator = new KeyValueAccumulator();

            if (string.IsNullOrEmpty(queryString) || queryString == "?")
            {
                return null;
            }

            int scanIndex = 0;
            if (queryString[0] == '?')
            {
                scanIndex = 1;
            }

            int textLength = queryString.Length;
            int equalIndex = queryString.IndexOf('=');
            if (equalIndex == -1)
            {
                equalIndex = textLength;
            }
            while (scanIndex < textLength)
            {
                int delimiterIndex = queryString.IndexOf('&', scanIndex);
                if (delimiterIndex == -1)
                {
                    delimiterIndex = textLength;
                }
                if (equalIndex < delimiterIndex)
                {
                    while (scanIndex != equalIndex && char.IsWhiteSpace(queryString[scanIndex]))
                    {
                        ++scanIndex;
                    }
                    string name = queryString.Substring(scanIndex, equalIndex - scanIndex);
                    string value = queryString.Substring(equalIndex + 1, delimiterIndex - equalIndex - 1);
                    accumulator.Append(
                        Uri.UnescapeDataString(name.Replace('+', ' ')),
                        Uri.UnescapeDataString(value.Replace('+', ' ')));
                    equalIndex = queryString.IndexOf('=', delimiterIndex);
                    if (equalIndex == -1)
                    {
                        equalIndex = textLength;
                    }
                }
                else
                {
                    if (delimiterIndex > scanIndex)
                    {
                        accumulator.Append(queryString.Substring(scanIndex, delimiterIndex - scanIndex), string.Empty);
                    }
                }
                scanIndex = delimiterIndex + 1;
            }

            if (!accumulator.HasValues)
            {
                return null;
            }

            return accumulator.GetResults();
        }

        public static string ConvertStringToUrl(string stringUrl)
        {
            return Regex.Replace(stringUrl, @"[^0-9a-zA-Z]+", "_");
        }
    }
}
