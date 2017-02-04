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
