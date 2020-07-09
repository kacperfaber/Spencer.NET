using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class assemblyregistrationbuilder_includeclass_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }

        class TestClass2
        {
        }

        class GenericClass<T>
        {
        }

        AssemblyRegistrationBuilder exec(AssemblyRegistrationBuilder builder, Type @class)
        {
            return (AssemblyRegistrationBuilder) builder.GetType().GetMethod("IncludeClass").MakeGenericMethod(@class).Invoke(builder, new object[0]);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            Assert.DoesNotThrow(() => exec(containerBuilder.RegisterAssembly(GetType().Assembly), typeof(TestClass)));
        }

        [Test]
        public void builder_has_more_RegistrationFlags_before_he_had()
        {
            AssemblyRegistrationBuilder assemblyBuilder = new ContainerBuilder()
                .RegisterAssembly(GetType().Assembly);

            int before = assemblyBuilder.Object.RegistrationFlags.Count;

            _ = exec(assemblyBuilder, typeof(TestClass));

            Assert.IsTrue(before < assemblyBuilder.Object.RegistrationFlags.Count);
        }

        [Test]
        public void builder_has_one_more_RegistrationFlag_before_he_had()
        {
            AssemblyRegistrationBuilder assemblyBuilder = new ContainerBuilder()
                .RegisterAssembly(GetType().Assembly);

            int before = assemblyBuilder.Object.RegistrationFlags.Count;

            _ = exec(assemblyBuilder, typeof(TestClass));

            Assert.IsTrue(before + 1 == assemblyBuilder.Object.RegistrationFlags.Count);
        }

        [Test]
        public void builder_Object_has_registration_flag_named_IncludeClass()
        {
            AssemblyRegistrationBuilder assemblyBuilder = new ContainerBuilder()
                .RegisterAssembly(GetType().Assembly);

            _ = exec(assemblyBuilder, typeof(TestClass));

            Assert.NotNull(assemblyBuilder.Object.RegistrationFlags.SingleOrDefault(x => x.Code == RegistrationFlagConstants.IncludeClass));
        }

        [TestCase(typeof(TestClass))]
        [TestCase(typeof(TestClass2))]
        [TestCase(typeof(GenericClass<int>))]
        public void builder_Object_has_registration_flag_named_IncludeClass_with_gived_type(Type type)
        {
            AssemblyRegistrationBuilder assemblyBuilder = new ContainerBuilder()
                .RegisterAssembly(GetType().Assembly);

            _ = exec(assemblyBuilder, type);

            ServiceRegistrationFlag flag = assemblyBuilder.Object.RegistrationFlags
                .SingleOrDefault(x => x.Code == RegistrationFlagConstants.IncludeClass);

            Assert.IsTrue((flag.Value as ClassRegistration).Class == type);
        }
    }
}