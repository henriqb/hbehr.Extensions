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