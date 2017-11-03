using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LNK.Infrastructure.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="DateTime"/>.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets first day of month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets first day of month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime? FirstDayOfMonth(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            return FirstDayOfMonth(dateTime.Value);
        }

        /// <summary>
        /// Gets last day of month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month), 23, 59, 59, DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets last day of month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime? LastDayOfMonth(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            return LastDayOfMonth(dateTime.Value);
        }

        /// <summary>
        /// Gets first day of previous month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime FirstDayOfPreviousMonth(this DateTime dateTime)
        {
            return FirstDayOfMonth(dateTime.AddMonths(-1));
        }

        /// <summary>
        /// Gets first day of previous month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime? FirstDayOfPreviousMonth(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            return FirstDayOfPreviousMonth(dateTime);
        }

        /// <summary>
        /// Gets first day of next month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime FirstDayOfNextMonth(this DateTime dateTime)
        {
            return FirstDayOfMonth(dateTime.AddMonths(1));
        }

        /// <summary>
        /// Gets first day of next month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime? FirstDayOfNextMonth(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            return FirstDayOfNextMonth(dateTime);
        }

        /// <summary>
        /// Gets last day of next month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime LastDayOfNextMonth(this DateTime dateTime)
        {
            return LastDayOfMonth(dateTime.AddMonths(1));
        }

        /// <summary>
        /// Gets last day of next month.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static DateTime? LastDayOfNextMonth(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
            {
                return null;
            }

            return LastDayOfNextMonth(dateTime);
        }

        /// <summary>
        /// Gets start of day
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime StartOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, DateTimeKind.Utc);
        }

        /// <summary>
        /// Gets end of day
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, DateTimeKind.Utc);
        }
    }
}