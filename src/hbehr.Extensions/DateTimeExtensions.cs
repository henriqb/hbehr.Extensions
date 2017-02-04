using System;

namespace hbehr.Extensions
{
    /// <summary>
    /// Extensions and Helpers for Date Time
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Formats a Date Time to PT-Br (Non US) string dd/MM/yyyy HH:mm
        /// Returns null if input is null
        /// </summary>
        /// <param name="date">Date to be formated</param>
        /// <returns>Formated date and time string representation</returns>
        public static string ToDateTimeStringPtBr(this DateTime? date)
        {
            return date?.ToString("dd/MM/yyyy HH:mm");
        }

        /// <summary>
        /// Formats a Date Time to PT-Br (Non US) string dd/MM/yyyy HH:mm
        /// </summary>
        /// <param name="date">Date to be formated</param>
        /// <returns>Formated date and time string representation</returns>
        public static string ToDateTimeStringPtBr(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm");
        }

        /// <summary>
        /// Formats a Date Time to PT-Br (Non US) date only string dd/MM/yyyy
        /// Returns null if input is null
        /// </summary>
        /// <param name="date">Date to be formated</param>
        /// <returns>Formated date and time string representation</returns>
        public static string ToDateStringPtBr(this DateTime? date)
        {
            return date?.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Formats a Date Time to PT-Br (Non US) date only string dd/MM/yyyy
        /// </summary>
        /// <param name="date">Date to be formated</param>
        /// <returns>Formated date and time string representation</returns>
        public static string ToDateStringPtBr(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Returns the largest of two dates. If they are both null, returns DateTime.MinValue
        /// </summary>
        /// <param name="d1">Date 1</param>
        /// <param name="d2">Date 2</param>
        /// <returns>Largest of two dates</returns>
        public static DateTime Max(this DateTime? d1, DateTime? d2)
        {
            if (d1 == null && d2 == null) return DateTime.MinValue;
            if (d1 == null) return d2.Value;
            if (d2 == null) return d1.Value;
            long ticks = Math.Max(d1.Value.Ticks, d2.Value.Ticks);
            return new DateTime(ticks);
        }

        /// <summary>
        /// Returns the largest of two dates. If they are both null, returns DateTime.MinValue
        /// </summary>
        /// <param name="d1">Date 1</param>
        /// <param name="d2">Date 2</param>
        /// <returns>Largest of two dates</returns>
        public static DateTime Max(this DateTime d1, DateTime? d2)
        {
            return Max((DateTime?)d1, d2);
        }

        /// <summary>
        /// Returns the smallest of two dates. If they are both null, returns DateTime.MinValue
        /// </summary>
        /// <param name="d1">Date 1</param>
        /// <param name="d2">Date 2</param>
        /// <returns>Smallest of two dates</returns>
        public static DateTime Min(this DateTime? d1, DateTime? d2)
        {
            if (d1 == null && d2 == null) return DateTime.MinValue;
            if (d1 == null) return d2.Value;
            if (d2 == null) return d1.Value;
            long ticks = Math.Min(d1.Value.Ticks, d2.Value.Ticks);
            return new DateTime(ticks);
        }

        /// <summary>
        /// Returns the smallest of two dates. If they are both null, returns DateTime.MinValue
        /// </summary>
        /// <param name="d1">Date 1</param>
        /// <param name="d2">Date 2</param>
        /// <returns>Smallest of two dates</returns>
        public static DateTime Min(this DateTime d1, DateTime? d2)
        {
            return Min((DateTime?)d1, d2);
        }
    }
}
