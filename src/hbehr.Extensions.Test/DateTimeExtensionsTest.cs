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
using NUnit.Framework;
using System;

namespace hbehr.Extensions.Test
{
    [TestFixture]
    public class DateTimeExtensionsTest
    {
        [Test]
        public void TestToDateTimeStringPtBr()
        {
            var date = new DateTime(2017, 01, 15, 18, 15, 00);

            string dateStr = date.ToDateTimeStringPtBr();
            Assert.AreEqual("15/01/2017 18:15", dateStr);

            dateStr = ((DateTime?)null).ToDateTimeStringPtBr();
            Assert.IsNull(dateStr);
        }

        [Test]
        public void TestToDateStringPtBr()
        {
            var date = new DateTime(2017, 01, 15, 18, 15, 00);

            string dateStr = date.ToDateStringPtBr();
            Assert.AreEqual("15/01/2017", dateStr);

            dateStr = ((DateTime?)null).ToDateStringPtBr();
            Assert.IsNull(dateStr);
        }

        [Test]
        public void TestMax()
        {
            DateTime? date = new DateTime(2017, 01, 15, 18, 15, 00);
            DateTime? date2 = new DateTime(2017, 05, 20, 15, 30, 00);

            var minDate = date.Max(date2);
            Assert.AreEqual(date2, minDate);

            date = null;
            minDate = date.Max(date2);
            Assert.AreEqual(date2, minDate);

            date2 = null;
            minDate = date.Max(date2);
            Assert.AreEqual(DateTime.MinValue, minDate);
        }

        [Test]
        public void TestMin()
        {
            DateTime? date = new DateTime(2017, 01, 15, 18, 15, 00);
            DateTime? date2 = new DateTime(2017, 05, 20, 15, 30, 00);

            var minDate = date.Min(date2);
            Assert.AreEqual(date.Value, minDate);

            date = null;
            minDate = date.Min(date2);
            Assert.AreEqual(date2, minDate);

            date2 = null;
            minDate = date.Min(date2);
            Assert.AreEqual(DateTime.MinValue, minDate);
        }
    }
}
