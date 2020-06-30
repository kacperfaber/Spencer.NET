using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class containerbuilder_registerclass_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }

        ClassRegistrationBuilder exec<T>(ContainerBuilder builder) where T : class
        {
            return builder.RegisterClass<T>();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>(new ContainerBuilder()));
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec<TestClass>(new ContainerBuilder()));
        }

        [Test]
        public void returns_ClassRegistrationBuilder_Object_not_null()
        {
            Assert.NotNull(exec<TestClass>(new ContainerBuilder()).Object);
        }

        [Test]
        public void returns_ClassRegistrationBuilder_ClassRegistration_Class_equals_to_gived_generic()
        {
            Type testClass = typeof(TestClass);

            Assert.AreEqual(testClass, exec<TestClass>(new ContainerBuilder()).Object.Class);
        }

        [Test]
        public void returns_ClassRegistrationBuilder_fields_dependencies_not_null()
        {
            ClassRegistrationBuilder builder = exec<TestClass>(new ContainerBuilder());
            Type builderType = builder.GetType();

            IEnumerable<FieldInfo> @interfaces = builderType.GetFields().Where(x => x.FieldType.IsInterface);

            foreach (FieldInfo @i in @interfaces)
            {
                object value = @i.GetValue(builder);
                
                Assert.NotNull(value);
            }
        }
        
        [Test]
        public void returns_ClassRegistrationBuilder_properties_dependencies_not_null()
        {
            ClassRegistrationBuilder builder = exec<TestClass>(new ContainerBuilder());
            Type builderType = builder.GetType();

            IEnumerable<PropertyInfo> @interfaces = builderType.GetProperties().Where(x => x.PropertyType.IsInterface);

            foreach (PropertyInfo i in @interfaces)
            {
                object value = i.GetValue(builder);
                
                Assert.NotNull(value);
            }
        }
    }
}