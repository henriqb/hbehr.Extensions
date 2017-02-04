using System;
using System.Linq;

namespace hbehr.Extensions
{
    public static class AttributeExtensions
    {
        /// <summary>
        /// Checks if a Object has the Attribute 'T'
        /// </summary>
        /// <typeparam name="T">Type of the Attribute</typeparam>
        /// <param name="obj">Object that is being checked</param>
        /// <returns>true/false if attribute is/isn't present on obj</returns>
        public static bool HasAttribute<T>(this object obj) where T : Attribute
        {
            return obj.GetType().GetCustomAttributes(true).Any(a => a.GetType() == typeof(T));
        }

        /// <summary>
        /// Get the Attribute 'T' from a Object
        /// </summary>
        /// <typeparam name="T">Type of the Attribute</typeparam>
        /// <param name="obj">Object to get the Attribute</param>
        /// <returns>The Attribute on the Object if found, if not found returns null</returns>
        public static T GetAttribute<T>(this object obj) where T : Attribute
        {
            return (T)obj.GetType().GetCustomAttributes(typeof(T), true).FirstOrDefault();
        }

        /// <summary>
        /// Get the Attribute 'T' from a Enum Value
        /// </summary>
        /// <typeparam name="T">Type of the Attribute</typeparam>
        /// <param name="enumObj">Enum Value to get the Attribnute</param>
        /// <returns>The Attribute on the Enum Value if found, if not found returns null</returns>
        public static T GetAttribute<T>(this Enum enumObj) where T : Attribute
        {
            return enumObj.GetType().GetMember(enumObj.ToString()).FirstOrDefault()?
                .GetCustomAttributes(typeof(T), true).Select(x => x as T).Where(x => x != null).FirstOrDefault();
        }
    }
}
