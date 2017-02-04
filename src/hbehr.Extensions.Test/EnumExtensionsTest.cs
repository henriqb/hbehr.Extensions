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
