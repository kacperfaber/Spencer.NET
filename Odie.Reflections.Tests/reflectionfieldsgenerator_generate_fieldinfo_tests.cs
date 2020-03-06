using System;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Reflections.Tests
{
    public class reflectionfieldsgenerator_generate_fieldinfo_tests
    {
        class Test
        {
#pragma warning disable
            public string Hello;
            public int World;
#pragma warning restore
        }

        FieldInfo get_field(string name)
        {
            return typeof(Test).GetField(name);
        }

        ReflectionField exec(FieldInfo info)
        {
            return new ReflectionFieldGenerator().Generate(info);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(get_field("Hello")));
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec(get_field("Hello")));
        }

        [Test]
        public void returns_instance_not_null_tests()
        {
            Assert.NotNull(exec(get_field("Hello")).Instance);
        }

        [Test]
        public void returns_instance_type_assignable_to_propertyinfo()
        {
            ReflectionField field = exec(get_field("Hello"));
            Type instanceType = field.Instance.GetType();

            Assert.IsTrue(typeof(FieldInfo).IsAssignableFrom(instanceType));
        }

        [Test]
        public void returns_membertype_is_property()
        {
            Assert.IsTrue(exec(get_field("Hello")).MemberType == MemberType.FIELD);
        }

        [Test]
        public void returns_type_is_matching_for_propertyinfo()
        {
            ReflectionField field = exec(get_field("Hello"));
            Assert.IsTrue(field.Type == field.Instance.GetType());
        }
    }
}