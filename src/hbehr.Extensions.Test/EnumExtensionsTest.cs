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
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace hbehr.Extensions.Test
{
    [TestFixture]
    public class EnumExtensionsTest
    {
        enum TestEnum
        {
            Field1 = 1,
            Field2 = 2,
            Field3 = 3
        }

        [Test]
        public void TestList()
        {
            var list = EnumExtensions.List<TestEnum>();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Any(x => x == TestEnum.Field1));
            Assert.AreEqual(3, list.Count());
        }

        [Test]
        public void TestListDynamic()
        {
            var list = TestEnum.Field1.GetType().List() as IEnumerable<dynamic>;
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Any(x => x == TestEnum.Field1));
            Assert.AreEqual(3, list.Count());
        }
    }
}
