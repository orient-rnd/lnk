using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="string"/>.
    /// </summary>
    public static class StringExtensions
    {
        public static DateTime? ConvertToDateTime(this string source, string format)
        {
            if (String.IsNullOrEmpty(source))
            {
                return null;
            }

            DateTime result;
            if (!DateTime.TryParseExact(source, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return null;
            }

            return result;
        }

        public static DateTime? ConvertToDateTime(this string source, string[] formats)
        {
            if (String.IsNullOrEmpty(source))
            {
                return null;
            }

            DateTime result;
            if (!DateTime.TryParseExact(source, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return null;
            }

            return result;
        }

        public static string Camelize(this string source, char spacer = '_')
        {
            if (String.IsNullOrEmpty(source))
            {
                return source;
            }

            /* Note that the .ToString() is required, otherwise the char is implicitly
             * converted to an integer and the wrong overloaded ctor is used */
            var sb = new StringBuilder(source[0].ToString());
            for (var i = 1; i < source.Length; i++)
            {
                if (source[i] == spacer)
                    sb.Append(Char.ToUpper(source[i++]));
                else
                    sb.Append(source[i]);
            }

            return sb.ToString();
        }

        public static string Decamelize(this string source, char spacer = '_')
        {
            if (String.IsNullOrEmpty(source))
            {
                return source;
            }

            /* Note that the .ToString() is required, otherwise the char is implicitly
             * converted to an integer and the wrong overloaded ctor is used */
            var sb = new StringBuilder(source[0].ToString());
            for (var i = 1; i < source.Length; i++)
            {
                if (Char.IsUpper(source, i))
                    sb.Append(spacer);
                sb.Append(source[i]);
            }

            return sb.ToString().ToLowerInvariant();
        }

        /// <summary>
        /// Substring from beginning
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringFromStart(this string source, int length)
        {
            if (String.IsNullOrWhiteSpace(source) || length >= source.Length)
            {
                return source;
            }

            return source.Substring(0, length);
        }

        /// <summary>
        /// Substring from trailing
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SubstringFromEnd(this string source, int length)
        {
            if (String.IsNullOrWhiteSpace(source) || length >= source.Length)
            {
                return source;
            }

            return source.Substring(source.Length - length);
        }

        /// <summary>
        /// Split a string by comma
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string[] SplitRemoveEmptyEntries(this string source)
        {
            return SplitRemoveEmptyEntries(source, ',');
        }

        /// <summary>
        /// Split a string by a character
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] SplitRemoveEmptyEntries(this string source, char separator)
        {
            return SplitRemoveEmptyEntries(source, new char[] { separator });
        }

        /// <summary>
        /// Split a string by characters
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] SplitRemoveEmptyEntries(this string source, char[] separator)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                return new string[] { };
            }

            return source.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Split a string by a string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] SplitRemoveEmptyEntries(this string source, string separator)
        {
            return SplitRemoveEmptyEntries(source, new string[] { separator });
        }

        /// <summary>
        /// Split a string by a string array
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] SplitRemoveEmptyEntries(this string source, string[] separator)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                return new string[] { };
            }

            return source.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Split a string by a string array
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string[] SplitRemoveEmptyEntries(this string source, string separator, int count)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                return new string[] { };
            }

            return source.Split(new string[] { separator }, count, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Determines whether a specified string is not null or empty.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string source)
        {
            return !String.IsNullOrWhiteSpace(source);
        }

        /// <summary>
        /// Determines whether a specified string is null or empty.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string source)
        {
            return String.IsNullOrWhiteSpace(source);
        }
    }
}