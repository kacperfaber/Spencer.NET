using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class classregistrationbuilder_asimplementedinterfaces_tests
    {
        interface ITestClass1
        {
        }

        interface ITestClass2
        {
        }

        class TestClass : ITestClass1, ITestClass2
        {
        }

        ClassRegistrationBuilder exec(ClassRegistrationBuilder builder)
        {
            return builder.AsImplementedInterfaces();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.DoesNotThrow(() => exec(builder));
        }

        [Test]
        public void returns_not_null()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.NotNull(exec(builder));
        }

        [Test]
        public void returns_equals_to_gived_builder_instance()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.AreEqual(builder, exec(builder));
        }

        [Test]
        public void returns_not_null_Object()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.NotNull(exec(builder).Object);
        }

        [Test]
        public void returns_equals_Object()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.AreEqual(builder.Object, exec(builder).Object);
        }

        [Test]
        public void returns_registration_flags_count_biggest_than_was()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            int before = builder.Object.RegistrationFlags.Count;
            int after = exec(builder).Object.RegistrationFlags.Count;
            
            Assert.IsTrue(before < after);
        }

        [Test]
        public void returns_registration_flags_contains_AsInterface_flag()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.NotNull(exec(builder).Object.RegistrationFlags.FirstOrDefault(x => x.Code == RegistrationFlagConstants.AsInterface));
        }

        [Test]
        public void returns_registration_flags_contains_AsInterface_flags_lenght_equals_to_TestClass_interfaces()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            IEnumerable<ServiceRegistrationFlag> flags = exec(builder).Object.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.AsInterface);
            
            Assert.IsTrue(flags.Count() == typeof(TestClass).GetInterfaces().Length);
        }

        [Test]
        public void returns_registration_flags_AsInterface_values_not_null()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            IEnumerable<ServiceRegistrationFlag> flags = exec(builder).Object.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.AsInterface);
            
            Assert.IsEmpty(flags.Where(x => x.Value is null));
        }

        [Test]
        public void returns_registration_flags_AsInterface_value_is_assignable_to_IInterface()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            IEnumerable<ServiceRegistrationFlag> flags = exec(builder).Object.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.AsInterface);

            foreach (ServiceRegistrationFlag flag in flags)
            {
                Assert.IsTrue(flag.Value is IInterface);
            }
        }

        [Test]
        public void returns_registration_flags_AsInterface_IInterface_Type_is_interface()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            IEnumerable<ServiceRegistrationFlag> flags = exec(builder).Object.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.AsInterface);

            foreach (ServiceRegistrationFlag serviceRegistrationFlag in flags)
            {
                Assert.IsTrue((serviceRegistrationFlag.Value as IInterface).Type.IsInterface);
            }
        }

        [Test]
        public void returns_each_registration_flag_AsInterface_IInterface_Type_is_interface_of_registered_class()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Type[] interfaces = typeof(TestClass).GetInterfaces();
            IEnumerable<ServiceRegistrationFlag> flags = exec(builder).Object.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.AsInterface);

            foreach (ServiceRegistrationFlag flag in flags)
            {
                IInterface i = flag.Value as IInterface;
                
                Assert.NotNull(interfaces.SingleOrDefault(x => x == i.Type));
            }
        }
    }
}