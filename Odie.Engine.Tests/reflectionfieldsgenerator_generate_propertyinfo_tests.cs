using System;
using System.Reflection;
using NUnit.Framework;

namespace Odie.Engine.Tests
{
    public class reflectionfieldsgenerator_generate_propertyinfo_tests
    {
        class Test
        {
            public string Hello { get; set; }
            public int World { get; set; }
        }

        PropertyInfo get_property(string name)
        {
            return typeof(Test).GetProperty(name);
        }
        
        ReflectionField exec(PropertyInfo info)
        {
            return new ReflectionFieldGenerator().Generate(info);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(get_property("Hello")));
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec(get_property("Hello")));
        }

        [Test]
        public void returns_instance_not_null_tests()
        {
            Assert.NotNull(exec(get_property("Hello")).Instance);
        }

        [Test]
        public void returns_instance_type_assignable_to_propertyinfo()
        {
            ReflectionField field = exec(get_property("Hello"));
            Type instanceType = field.Instance.GetType();

            Console.WriteLine(instanceType.FullName);
            
            Assert.IsTrue(typeof(PropertyInfo).IsAssignableFrom(instanceType));
        }

        [Test]
        public void returns_membertype_is_property()
        {
            Assert.IsTrue(exec(get_property("Hello")).MemberType == MemberType.PROPERTY);
        }

        [Test]
        public void returns_type_is_matching_for_propertyinfo()
        {
            ReflectionField field = exec(get_property("Hello"));
            Assert.IsTrue(field.Type == field.Instance.GetType());
        }
    }
}