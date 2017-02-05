/* The MIT License (MIT)

Copyright (c) 2014 - 2017 Henrique Borba Behr

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
