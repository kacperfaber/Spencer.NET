using System;
using System.Linq.Expressions;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class membervaluesetter_setvalue_member_object_object_tests
    {
        class TestClass
        {
#pragma warning disable
            public object PublicProperty { get; set; }
            public object PublicField;
#pragma warning restore
        }

        void exec(Expression<Func<TestClass, object>> expression, object value, object instance)
        {
            MemberInfo memberInfo = ((MemberExpression) expression.Body).Member;
            IMember member = new MemberGenerator(new MemberFlagsGenerator()).GenerateMember(memberInfo);

            new MemberValueSetter().SetValue(member, instance, value);
        }

        [Test]
        public void dont_throws_exceptions_if_target_is_property()
        {
            TestClass test = new TestClass();

            Assert.DoesNotThrow(() => exec(t => t.PublicProperty, null, test));
        }

        [Test]
        public void dont_throws_exceptions_if_target_is_field()
        {
            TestClass test = new TestClass();

            Assert.DoesNotThrow(() => exec(t => t.PublicField, null, test));
        }

        [Test]
        public void throws_if_instance_is_null_and_target_is_property()
        {
            Assert.That(() => exec(t => t.PublicProperty, null, null), Throws.Exception);
        }

        [Test]
        public void throws_if_instance_is_null_and_target_is_field()
        {
            Assert.That(() => exec(t => t.PublicField, null, null), Throws.Exception);
        }

        [Test]
        public void works_if_target_is_property()
        {
            object val = Guid.NewGuid().ToString();
            TestClass testClass = new TestClass();

            exec(t => t.PublicProperty, val, testClass);

            Assert.AreEqual(val, testClass.PublicProperty);
        }

        [Test]
        public void works_if_target_is_field()
        {
            object val = Guid.NewGuid().ToString();
            TestClass testClass = new TestClass();

            exec(t => t.PublicField, val, testClass);

            Assert.AreEqual(val, testClass.PublicField);
        }
    }
}