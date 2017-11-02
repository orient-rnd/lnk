using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="object"/>.
    /// </summary>
    public static class ObjectExtensions
    {
        private static readonly string[] Booleans = new string[] { "true", "yes", "on", "1" };

        /// <summary>
        /// Convert object to int.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static int AsInt(this object value, IFormatProvider provider = null)
        {
            return As<int>(value, provider);
        }

        /// <summary>
        /// Convert object to int.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static int AsInt(this object value, int defaultValue, IFormatProvider provider = null)
        {
            return As<int>(value, defaultValue, provider);
        }

        /// <summary>
        /// Convert object to float.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static float AsFloat(this object value, IFormatProvider provider = null)
        {
            return As<float>(value, provider);
        }

        /// <summary>
        /// Convert object to float.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static float AsFloat(this object value, float defaultValue, IFormatProvider provider = null)
        {
            return As<float>(value, defaultValue, provider);
        }

        /// <summary>
        /// Convert object to decimal.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static decimal AsDecimal(this object value, IFormatProvider provider = null)
        {
            return As<decimal>(value, provider);
        }

        /// <summary>
        /// Convert object to decimal.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static decimal AsDecimal(this object value, decimal defaultValue, IFormatProvider provider = null)
        {
            return As<decimal>(value, defaultValue, provider);
        }

        /// <summary>
        /// Convert object to double.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static double AsDouble(this object value, IFormatProvider provider = null)
        {
            return As<double>(value, provider);
        }

        /// <summary>
        /// Convert object to double.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static double AsDouble(this object value, double defaultValue, IFormatProvider provider = null)
        {
            return As<double>(value, defaultValue, provider);
        }

        /// <summary>
        /// Convert object to long.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static long AsLong(this object value, IFormatProvider provider = null)
        {
            return As<long>(value, provider);
        }

        /// <summary>
        /// Convert object to long.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static long AsLong(this object value, long defaultValue, IFormatProvider provider = null)
        {
            return As<long>(value, defaultValue, provider);
        }

        /// <summary>
        /// Convert object to bool.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool AsBoolean(this object value)
        {
            return AsBoolean(value, default(bool));
        }

        /// <summary>
        /// Convert object to bool.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool AsBoolean(this object value, bool defaultValue)
        {
            if (value != null)
            {
                string valueString = value.ToString();
                if (!String.IsNullOrWhiteSpace(valueString))
                {
                    return Booleans.Contains(valueString, StringComparer.OrdinalIgnoreCase);
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Convert object to string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static string AsString(this object value, IFormatProvider provider = null)
        {
            return As<string>(value, String.Empty, provider);
        }

        /// <summary>
        /// Convert object to string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static string AsString(this object value, string defaultValue, IFormatProvider provider = null)
        {
            return As<string>(value, defaultValue, provider);
        }

        /// <summary>
        /// Convert object to date time.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static DateTime AsDateTime(this object value, IFormatProvider provider = null)
        {
            return As<DateTime>(value, provider);
        }

        /// <summary>
        /// Convert string to date time.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static DateTime? AsDateTime(this string value, IFormatProvider provider = null)
        {
            if (String.IsNullOrEmpty(value))
            {
                return null;
            }

            DateTime date = DateTime.UtcNow;

            if (DateTime.TryParse(value, out date))
            {
                return date;
            }

            return null;
        }

        /// <summary>
        /// Convert object to date time.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static DateTime AsDateTime(this object value, DateTime defaultValue, IFormatProvider provider = null)
        {
            return As<DateTime>(value, defaultValue, provider);
        }

        /// <summary>
        /// Convert object to a specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static T As<T>(this object value, IFormatProvider provider = null)
        {
            return As<T>(value, default(T), provider);
        }

        /// <summary>
        /// Convert object to a specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static T As<T>(this object value, T defaultValue, IFormatProvider provider = null)
        {
            T convertedValue = defaultValue;
            if (value != null && value is IConvertible)
            {
                try
                {
                    convertedValue = (T)value;
                }
                catch
                {
                    try
                    {
                        if (provider == null)
                        {
                            convertedValue = (T)Convert.ChangeType(value, typeof(T));
                        }
                        else
                        {
                            convertedValue = (T)Convert.ChangeType(value, typeof(T), provider);
                        }
                    }
                    catch
                    {
                    }
                }
            }

            return convertedValue;
        }

        /// <summary>
        /// Converts current <see cref="object"/> instance to a dictionary, which includes all public non-static properties and its values.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="appendDictionary">The append dictionary.</param>
        /// <param name="allCachedPropertiesOfObjTypes">All cached properties of obj types.</param>
        /// <returns></returns>
        public static IDictionary<string, object> AsDictionary(this object obj, IDictionary<string, object> appendDictionary = null, Dictionary<string, ICollection<PropertyInfo>> allCachedPropertiesOfObjTypes = null)
        {
            if (obj == null)
            {
                return null;
            }

            Dictionary<string, object> dictionary = appendDictionary == null ? new Dictionary<string, object>() : new Dictionary<string, object>(appendDictionary);

            string objName = obj.GetType().FullName;
            ICollection<PropertyInfo> properties = null;

            if (allCachedPropertiesOfObjTypes != null)
            {
                if (allCachedPropertiesOfObjTypes.TryGetValue(objName, out properties))
                {
                }
            }

            if (properties == null)
            {
                properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                try
                {
                    if (allCachedPropertiesOfObjTypes != null)
                    {
                        allCachedPropertiesOfObjTypes[objName] = properties;
                    }
                }
                catch (Exception)
                {
                }
            }

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                dictionary[property.Name] = value;
            }

            return dictionary;
        }

        public static Dictionary<string, string> AsDictionary(this NameValueCollection namevalueCollection)
        {
            if (namevalueCollection == null)
            {
                return null;
            }

            var dictionary = new Dictionary<string, string>();
            var keys = namevalueCollection.AllKeys;
            foreach (var key in keys)
            { 
                dictionary[key] = namevalueCollection[key];
            }

            return dictionary;
        }

    }
}