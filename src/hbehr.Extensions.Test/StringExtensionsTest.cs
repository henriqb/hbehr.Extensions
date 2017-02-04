using NUnit.Framework;
using System;

namespace hbehr.Extensions.Test
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void TestSplit()
        {
            string str = "StringToSplit";
            var split = str.Split("To");
            Assert.AreEqual("String", split[0]);
            Assert.AreEqual("Split", split[1]);

            split = str.Split("ToSplit");
            Assert.AreEqual("String", split[0]);
            Assert.IsEmpty(split[1]);

            split = str.Split("ToSplit", StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual("String", split[0]);
            Assert.AreEqual(1, split.Length);

            str = null;
            split = str.Split("To");
            Assert.IsNull(str);
        }

        [Test]
        public void TestSafeSubstring()
        {
            string str = "StringToSubstring";
            var sub = str.SafeSubstring(4);
            Assert.AreEqual("ngToSubstring", sub);

            sub = str.SafeSubstring(4, 10);
            Assert.AreEqual("ngToSubstr", sub);

            sub = str.SafeSubstring(200);
            Assert.IsEmpty(sub);

            sub = str.SafeSubstring(4, 200);
            Assert.AreEqual("ngToSubstring", sub);
        }

        [Test]
        public void TestGetNumberOnly()
        {
            string str = null;
            Assert.Throws<ArgumentException>(() => str.GetNumberOnly());

            str = "AA1@@23|||BBCC44--**55";
            var filtered = str.GetNumberOnly();
            Assert.AreEqual("1234455", filtered);
        }

        [Test]
        public void TestCleanString()
        {
            string str = null;
            Assert.Throws<ArgumentException>(() => str.CleanString());

            str = "AA1@@23|||BBCC44--**55";
            var filtered = str.CleanString();
            Assert.AreEqual("aa123bbcc4455", filtered);
        }

        [Test]
        public void TestFirstCharToUpper()
        {
            string str = null;
            string firstCharToUpper = str.FirstCharToUpper();
            Assert.IsEmpty(firstCharToUpper);

            str = "test";
            firstCharToUpper = str.FirstCharToUpper();
            Assert.AreEqual("Test", firstCharToUpper);

            str = "Test";
            firstCharToUpper = str.FirstCharToUpper();
            Assert.AreEqual("Test", firstCharToUpper);

            str = "t";
            firstCharToUpper = str.FirstCharToUpper();
            Assert.AreEqual("T", firstCharToUpper);

            str = "";
            firstCharToUpper = str.FirstCharToUpper();
            Assert.IsEmpty(firstCharToUpper);

            str = "123test";
            firstCharToUpper = str.FirstCharToUpper();
            Assert.AreEqual("123test", firstCharToUpper);
        }
    }
}