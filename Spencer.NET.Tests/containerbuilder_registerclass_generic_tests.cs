using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class containerbuilder_registerclass_generic_tests
    {
        class TestClass
        {
            public TestClass MakeInstance() => new TestClass();
        }

        ClassRegistrationBuilder exec<T>(ContainerBuilder builder) where T : class
        {
            return builder.RegisterClass<T>();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            Assert.DoesNotThrow(() => { _ = exec<TestClass>(containerBuilder); });
        }

        [Test]
        public void returns_instance_of_ClassRegistrationBuilder()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            Assert.IsInstanceOf<ClassRegistrationBuilder>(exec<TestClass>(containerBuilder));
        }

        [Test]
        public void returns_ClassRegistrationBuilder_with_not_null_ClassRegistration()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            Assert.NotNull(exec<TestClass>(containerBuilder).Object);
        }

        [TestCase(typeof(TestClass))]
        [TestCase(typeof(object))]
        [TestCase(typeof(containerbuilder_registerclass_generic_tests))]
        public void returns_ClassRegistration_ClassRegistration_with_excepted_type(Type registrationType)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            MethodInfo genericMethod = GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.ReturnType == typeof(ClassRegistrationBuilder))
                .FirstOrDefault(x => x.Name == "exec")
                .MakeGenericMethod(registrationType);

            ClassRegistrationBuilder builder = (ClassRegistrationBuilder) genericMethod.Invoke(this, new[] {containerBuilder});

            Assert.IsTrue(builder.Object.Class == registrationType);
        }
    }
}