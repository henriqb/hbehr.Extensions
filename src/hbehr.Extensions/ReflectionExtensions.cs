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
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace hbehr.Extensions
{
    /// <summary>
    /// Extensions and Helpers for Reflection
    /// </summary>
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Implements get value from a MemberInfo (Property or Field)
        /// </summary>
        /// <typeparam name="T">Type of value to return</typeparam>
        /// <param name="memberInfo">A property or Field</param>
        /// <param name="obj">Obj to get the value</param>
        /// <returns></returns>
        public static T GetValue<T>(this MemberInfo memberInfo, object obj)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return (T)((FieldInfo)memberInfo).GetValue(obj);
                case MemberTypes.Property:
                    return (T)((PropertyInfo)memberInfo).GetValue(obj);
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Sets a value into a MemberInfo (Property or Field)
        /// </summary>
        /// <param name="memberInfo">Property or Field Info</param>
        /// <param name="obj">Object to set the value</param>
        /// <param name="value">Value to be set</param>
        public static void SetValue(this MemberInfo memberInfo, object obj, object value)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    ((FieldInfo)memberInfo).SetValue(obj, value); break;
                case MemberTypes.Property:
                    ((PropertyInfo)memberInfo).SetValue(obj, value); break;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns type implemented by a Field/Property
        /// </summary>
        /// <param name="memberInfo">Property or Field Info</param>
        /// <returns></returns>
        public static Type GetMemberPropertyOrFieldType(this MemberInfo memberInfo)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).FieldType;
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).PropertyType;
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns if a class has a Property defined
        /// </summary>
        /// <param name="type">Type of the Class</param>
        /// <param name="propertyName">Name of the property</param>
        /// <returns>True if property is present on class</returns>
        public static bool ObjectHasProperty(this Type type, string propertyName)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Any(p => p.Name.Equals(propertyName));
        }

        /// <summary>
        /// Converts an object to a ExpandoObject, copying all Public Instance properties
        /// </summary>
        /// <param name="obj">Object to be converted</param>
        /// <returns>An ExpandoObject containing all public instance properties of the original object</returns>
        public static ExpandoObject AsExpando(this object obj)
        {
            if (obj is ExpandoObject expando) { return expando; }
            expando = new ExpandoObject();
            foreach (var prop in obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                expando.AddProperty(prop.Name, prop.GetValue(obj));
            }
            return expando;
        }

        /// <summary>
        /// Transforms a object into a dynamic, implementation of IDictionary, and adds a new Property into it.
        /// </summary>
        /// <param name="obj">Object to be implemented</param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns>A new Expando with </returns>
        public static ExpandoObject AddProperty(this object obj, string propertyName, object value)
        {
            ExpandoObject expando = obj.AsExpando();
            expando.AddProperty(propertyName, value);
            return expando;
        }     

        private static void AddProperty(this ExpandoObject expando, string propertyName, object propertyValue)
        {
            var expandoDict = expando as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
            {
                expandoDict[propertyName] = propertyValue;
                return;
            }
            expandoDict.Add(propertyName, propertyValue);
        }
    }
}