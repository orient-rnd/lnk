using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IDictionary{TKey,TValue}"/>.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Gets the element with the specified key and convert to int.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetInt<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return GetValue<TKey, TValue, int>(dictionary, key);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to int.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int GetInt<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, int defaultValue)
        {
            return GetValue<TKey, TValue, int>(dictionary, key, defaultValue);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to float.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static float GetFloat<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return GetValue<TKey, TValue, float>(dictionary, key);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to float.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static float GetFloat<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, float defaultValue)
        {
            return GetValue<TKey, TValue, float>(dictionary, key, defaultValue);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to decimal.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetDecimal<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return GetValue<TKey, TValue, decimal>(dictionary, key);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to decimal.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static decimal GetDecimal<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, decimal defaultValue)
        {
            return GetValue<TKey, TValue, decimal>(dictionary, key, defaultValue);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to double.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static double GetDouble<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return GetValue<TKey, TValue, double>(dictionary, key);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to double.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static double GetDouble<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, double defaultValue)
        {
            return GetValue<TKey, TValue, double>(dictionary, key, defaultValue);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to long.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long GetLong<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return GetValue<TKey, TValue, long>(dictionary, key);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to long.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static long GetLong<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, long defaultValue)
        {
            return GetValue<TKey, TValue, long>(dictionary, key, defaultValue);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to bool.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetBoolean<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return GetBoolean(dictionary, key, false);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to bool.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool GetBoolean<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, bool defaultValue)
        {
            if (dictionary != null && dictionary.ContainsKey(key) && dictionary[key] != null)
            {
                return dictionary[key].AsBoolean(defaultValue);
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the element with the specified key and convert to string.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return GetValue<TKey, TValue, string>(dictionary, key, String.Empty);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to string.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, string defaultValue)
        {
            return GetValue<TKey, TValue, string>(dictionary, key, defaultValue);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to date time.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static DateTime GetDateTime<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return GetValue<TKey, TValue, DateTime>(dictionary, key);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to date time.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime GetDateTime<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, DateTime defaultValue)
        {
            return GetValue<TKey, TValue, DateTime>(dictionary, key, defaultValue);
        }

        /// <summary>
        /// Gets the element with the specified key and convert to a specified type.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValue<TKey, TValue, T>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.GetValue<TKey, TValue, T>(key, default(T));
        }

        /// <summary>
        /// Gets the element with the specified key and convert to a specified type.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T GetValue<TKey, TValue, T>(this IDictionary<TKey, TValue> dictionary, TKey key, T defaultValue)
        {
            if (dictionary != null && dictionary.ContainsKey(key) && dictionary[key] != null)
            {
                return dictionary[key].As<T>(defaultValue);
            }

            return defaultValue;
        }

        public static TValue GetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary != null && dictionary.ContainsKey(key) && dictionary[key] != null)
            {
                return dictionary[key];
            }

            return default(TValue);
        }

        public static NameValueCollection ToNameValueCollection<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            NameValueCollection nameValueCollection = new NameValueCollection();

            foreach (KeyValuePair<TKey, TValue> kvp in dictionary)
            {
                string value = null;
                if (kvp.Value != null)
                {
                    value = kvp.Value.ToString();
                }

                nameValueCollection.Add(kvp.Key.ToString(), value);
            }

            return nameValueCollection;
        }
    }
}