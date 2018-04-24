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
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace hbehr.Extensions.TestNetFramework
{
    [TestFixture]
    public class ReflectionExtensionsTest
    {
        [Test]
        public void TestGetValue()
        {
            var obj = new TestClass { Property1 = 1, Property3 = '3', Field1 = 1.2 };
            var members = obj.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property)
                .Where(m => !m.Name.Contains("Backing")).ToArray();

            var intValue = members[0].GetValue<int>(obj);
            Assert.AreEqual(1, intValue);

            var stringValue = members[1].GetValue<string>(obj);
            Assert.IsEmpty(stringValue ?? string.Empty);

            var charValue = members[2].GetValue<char>(obj);
            Assert.AreEqual('3', charValue);

            var doubleValue = members[3].GetValue<double>(obj);
            Assert.AreEqual(1.2, doubleValue, 0.001);
        }

        [Test]
        public void TestSetValue()
        {
            var obj = new TestClass { Property1 = 1, Property3 = '3', Field1 = 1.2 };
            var members = obj.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property)
                .Where(m => !m.Name.Contains("Backing")).ToArray();

            members[0].SetValue(obj, 23);
            Assert.AreEqual(23, obj.Property1);

            members[1].SetValue(obj, "NewValue");
            var stringValue = members[1].GetValue<string>(obj);
            Assert.AreEqual("NewValue", stringValue);

            members[2].SetValue(obj, 'A');
            Assert.AreEqual('A', obj.Property3);

            members[3].SetValue(obj, 23.44);
            Assert.AreEqual(23.44, obj.Field1, 0.001);
        }

        [Test]
        public void GetMemberPropertyOrFieldType()
        {
            var obj = new TestClass { Property1 = 1, Property3 = '3', Field1 = 1.2 };
            var members = obj.GetType().GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(m => m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property)
                .Where(m => !m.Name.Contains("Backing")).ToArray();

            var type = members[0].GetMemberPropertyOrFieldType();
            Assert.AreEqual(typeof(int), type);

            type = members[1].GetMemberPropertyOrFieldType();
            Assert.AreEqual(typeof(string), type);

            type = members[2].GetMemberPropertyOrFieldType();
            Assert.AreEqual(typeof(char), type);

            type = members[3].GetMemberPropertyOrFieldType();
            Assert.AreEqual(typeof(double), type);
        }

        [Test]
        public void TestObjectHasProperty()
        {
            Assert.IsTrue(typeof(TestClass).ObjectHasProperty("Property1"));
            Assert.IsTrue(typeof(TestClass).ObjectHasProperty("Property2"));
            Assert.IsTrue(typeof(TestClass).ObjectHasProperty("Property3"));
            Assert.IsFalse(typeof(TestClass).ObjectHasProperty("Field1"));
            Assert.IsFalse(typeof(TestClass).ObjectHasProperty("@@@@@@@@@@@@@@"));
        }

        [Test]
        public void TestAsExpando()
        {
            var obj = new TestClass { Property1 = 1, Property3 = '3', Field1 = 1.2 };
            dynamic expando = obj.AsExpando();
            Assert.AreEqual(1, expando.Property1);
            Assert.AreEqual('3', expando.Property3);
            var dic = expando as IDictionary<string, object>;
            Assert.IsFalse(dic.ContainsKey("Property2"));
            Assert.IsFalse(dic.ContainsKey("Field1"));

            dynamic expando2 = (expando as ExpandoObject).AsExpando();
            Assert.AreEqual(expando, expando2);
        }

        [Test]
        public void TestAddProperty()
        {
            var obj = new TestClass { Property1 = 1, Property3 = '3', Field1 = 1.2 };
            dynamic newObj = obj.AddProperty("Property4", new TestClass { Property1 = 10 });
            Assert.AreEqual(10, newObj.Property4.Property1);
            Assert.AreEqual(1, newObj.Property1);
            Assert.AreEqual('3', newObj.Property3);
        }

        [Test]
        public void TestIsSubclassOfRawGeneric()
        {
            Assert.IsTrue(typeof(Implementation).IsSubclassOfRawGeneric(typeof(BaseClass<>)));
            Assert.IsFalse(typeof(TestClass).IsSubclassOfRawGeneric(typeof(BaseClass<>)));
        }

        class Implementation : BaseClass<TestClass> { }

        class BaseClass<T>
        {
            int Test1 { get; set; }
        }

        class TestClass
        {
            public int Property1 { get; set; }
            private string Property2 { get; set; }
            public char Property3 { get; set; }
            public double Field1;
        }
    }
}
