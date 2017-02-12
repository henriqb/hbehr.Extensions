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
using System.Text;

namespace hbehr.Extensions
{
    /// <summary>
    /// Extensions and Helpers for String
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Splits a string into substrings based on the separator, you can add a option to remove empty entrys
        /// </summary>
        /// <param name="str">The string to be split</param>
        /// <param name="separator">A string that delimits the substring</param>
        /// <param name="options">Can be changed to remove empty substrings</param>
        /// <returns>An array of substrings from the main string splited by the separator</returns>
        public static string[] Split(this string str, string separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return str?.Split(new[] { separator }, options);
        }

        /// <summary>
        /// Does the same as SubString, but dosen't throws exceptions, if start > length returns string.Empty
        /// </summary>
        /// <param name="str">Main string</param>
        /// <param name="start">Index to start</param>
        /// <returns>A Substring from the main string starting at index [start] till the end</returns>
        public static string SafeSubstring(this string str, int start)
        {
            if (str == null) return null;
            return str.Length <= start ? "" : str.Substring(start);
        }

        /// <summary>
        /// Does the same as SubString, but dosen't throws exceptions, if start > string.Length returns string.Empty, 
        /// if length + string > string.Length, returns from the start till the end.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="start">The zero-based starting character position of a substring in this instance</param>
        /// <param name="length">The number of characters in the substring</param>
        /// <returns>A Substring from the main string starting at index [start] till [start]+[length] index</returns>
        public static string SafeSubstring(this string str, int start, int length)
        {
            if (str == null) return null;
            return str.Length <= start ? ""
                : str.Length - start <= length ? str.Substring(start)
                : str.Substring(start, length);
        }

        /// <summary>
        /// Filters a string and returns a substring with only the numeric characters of the main string
        /// </summary>
        /// <param name="str">String to be filtered</param>
        /// <returns>A digit only string</returns>
        public static string GetNumberOnly(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(nameof(str));
            }

            var builder = new StringBuilder();
            foreach (char c in str)
            {
                if (char.IsDigit(c)) builder.Append(c);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Filters a string and returns a string with only leters and numeric characters of the main string
        /// </summary>
        /// <param name="str">String to be cleaned</param>
        /// <returns>A digit and letter only string</returns>
        public static string CleanString(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException(nameof(str));
            }

            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().Normalize().ToLower();
        }

        /// <summary>
        /// Applies the Levenshtein in Distance Algorithim, to find the proximity of two strings
        /// </summary>
        /// <param name="s">The first string to be compared</param>
        /// <param name="t">The other string to be compared</param>
        /// <returns>An integer representing how many characters have to be changed to string s be equal to t</returns>
        public static int LevenshteinDistance(this string s, string t)
        {
            if (string.IsNullOrEmpty(s))
            {
                if (string.IsNullOrEmpty(t))
                    return 0;
                return t.Length;
            }

            if (string.IsNullOrEmpty(t))
            {
                return s.Length;
            }

            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // initialize the top and right of the table to 0, 1, 2, ...
            for (int i = 0; i <= n; d[i, 0] = i++) ;
            for (int j = 1; j <= m; d[0, j] = j++) ;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
                    int min1 = d[i - 1, j] + 1;
                    int min2 = d[i, j - 1] + 1;
                    int min3 = d[i - 1, j - 1] + cost;
                    d[i, j] = Math.Min(Math.Min(min1, min2), min3);
                }
            }
            return d[n, m];
        }

        /// <summary>
        /// Converts the first letter of a string to Upper Case: Example "test" -> "Test"
        /// </summary>
        /// <param name="str">String to have the first letter upper case</param>
        /// <returns>The string with the first letter upper case</returns>
        public static string FirstCharToUpper(this string str)
        {
            return str?.Any() == true ? str.First().ToString().ToUpper() + str.SafeSubstring(1) : string.Empty;
        }

        /// <summary>
        /// Removes character Zero Width No-Break Space '' (65279) from a string
        /// </summary>
        /// <param name="str">String to be cleaned</param>
        /// <returns>The string without '' (65279) character</returns>
        public static string RemoveZeroWidthNoBreakSpace(this string str)
        {
            return str?.Replace(Constants.ZeroWidthNoBreakSpace.ToString(), string.Empty);
        }

        /// <summary>
        /// Remove all HTML tags and replace &nbsp; for ' '
        /// </summary>
        /// <param name="str">HTML string</param>
        /// <returns>Pure text</returns>
        public static string StripHTML(this string str)
        {
            StringBuilder sb = new StringBuilder();            
            bool htmlTag = false;
            str = str.Replace("&nbps;", " ");
            foreach (char c in str)
            {
                if ('<'.Equals(c))
                {
                    htmlTag = true;
                    continue;
                }
                if ('>'.Equals(c))
                {
                    htmlTag = false;
                    continue;
                }
                if (htmlTag) { continue; }
                sb.Append(c);
            }
            return sb.ToString().Trim();
        }
    }
}