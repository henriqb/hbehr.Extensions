using NUnit.Framework;
using System;

namespace hbehr.Extensions.Test
{
    [TestFixture]
    public class AttributeExtensionsTest
    {
        private const int Identificator = 50592;

        [Test]
        public void TestHasAttribute()
        {
            var classWithAttribute = new ClassWithAttribute();
            Assert.IsTrue(classWithAttribute.HasAttribute<TestAttAttribute>());

            var classWithoutAttribute = new ClassWithoutAttribute();
            Assert.IsFalse(classWithoutAttribute.HasAttribute<TestAttAttribute>());
        }

        [Test]
        public void TestGetAttribute()
        {
            var classWithAttribute = new ClassWithAttribute();
            var testAttribute = classWithAttribute.GetAttribute<TestAttAttribute>();
            Assert.IsNotNull(testAttribute);
            Assert.AreEqual(Identificator, testAttribute.Id);

            var classWithoutAttribute = new ClassWithoutAttribute();
            testAttribute = classWithoutAttribute.GetAttribute<TestAttAttribute>();
            Assert.IsNull(testAttribute);
        }

        [Test]
        public void TestGetAttributeEnum()
        {
            var testAttribute = EnumTest.Field1.GetAttribute<TestAttAttribute>();
            Assert.IsNotNull(testAttribute);
            Assert.AreEqual(Identificator, testAttribute.Id);

            testAttribute = EnumTest.Field2.GetAttribute<TestAttAttribute>();
            Assert.IsNull(testAttribute);
        }

        [TestAtt(Identificator)]
        class ClassWithAttribute { }

        class ClassWithoutAttribute { }

        enum EnumTest
        {
            [TestAtt(Identificator)]
            Field1,            
            Field2
        }

        class TestAttAttribute : Attribute
        {
            public TestAttAttribute(int id)
            {
                Id = id;
            }

            public int Id { get; set; }
        }
    }
}
