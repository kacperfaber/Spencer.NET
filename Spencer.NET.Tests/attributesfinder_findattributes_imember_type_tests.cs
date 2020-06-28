using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class attributesfinder_findattributes_imember_type_tests
    {
        interface ITestClass
        {
        }

        class TestClassAttribute : Attribute
        {
        }

        class NewAttribute : Attribute
        {
        }

        class TestClass : ITestClass
        {
            [TestClass]
            public string Name { get; set; }

            [NewAttribute]
            [TestClass]
            public string Email { get; set; }

            public string FirstName { get; set; }
        }

        IEnumerable<Attribute> exec<T>(Expression<Func<T, object>> expression, Type attrType)
        {
            MemberInfo memberInfo = (expression.Body as MemberExpression).Member;
            IMember member = new MemberBuilder()
                .AddMemberInfo(memberInfo)
                .Build();

            return new AttributesFinder().FindAttributes(member, attrType);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>(x => x.Email, typeof(TestClassAttribute)));
        }

        [Test]
        public void returns_one_if_target_member_was_Name_and_attribute_type_was_TestClassAttribute()
        {
            IEnumerable<Attribute> attributes = exec<TestClass>(x => x.Name, typeof(TestClassAttribute));

            Assert.IsTrue(attributes.Count() == 1);
        }

        [Test]
        public void returns_two_if_target_member_was_Email_and_attribute_type_was_Attribute()
        {
            IEnumerable<Attribute> attributes = exec<TestClass>(x => x.Email, typeof(Attribute));

            Assert.IsTrue(attributes.Count() == 2);
        }

        [Test]
        public void returns_single_TestClassAttribute_if_target_member_was_Name()
        {
            IEnumerable<Attribute> attributes = exec<TestClass>(x => x.Name, typeof(Attribute));
            
            Assert.NotNull(attributes.SingleOrDefault(x => x is TestClassAttribute));
        }

        [Test]
        public void returns_empty_if_target_was_FirstName()
        {
            IEnumerable<Attribute> attributes = exec<TestClass>(x => x.FirstName, typeof(Attribute));
            
            Assert.IsEmpty(attributes);
        }
    }
}