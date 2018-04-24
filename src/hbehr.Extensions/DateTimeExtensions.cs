/* The MIT License (MIT)

Copyright (c) 2014 - 2018 Henrique Borba Behr

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. */
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
