using System;
using System.Collections.Generic;
using System.Linq;

namespace hbehr.Extensions
{
    /// <summary>
    /// Extensions and Helpers for Enum
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// List all Enum Values
        /// </summary>
        /// <typeparam name="T">A Enum Type</typeparam>
        /// <returns>An IEnumerable that contains all of the Enum T values</returns>
        public static IEnumerable<T> List<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// List all Enum Values
        /// </summary>
        /// <typeparam name="T">A Enum Type</typeparam>
        /// <returns>An IEnumerable that contains all of the Enum T values</returns>
        public static IEnumerable<dynamic> List(this Type t)
        {
            return Enum.GetValues(t).Cast<dynamic>();
        }
    }
}
