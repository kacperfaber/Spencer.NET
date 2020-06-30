using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class classregistrationbuilder_asinterface_tests
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

        class ItIsNotInterface
        {
        }

        ClassRegistrationBuilder exec<T>(ClassRegistrationBuilder builder)
        {
            return builder.AsInterface<T>();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.DoesNotThrow(() => exec<ITestClass1>(builder));
        }

        [Test]
        public void returns_not_null()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.NotNull(exec<ITestClass1>(builder));
        }

        [Test]
        public void returns_equals_to_gived_builder_instance()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.AreEqual(builder, exec<ITestClass1>(builder));
        }

        [Test]
        public void returns_not_null_Object()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.NotNull(exec<ITestClass1>(builder).Object);
        }

        [Test]
        public void returns_equals_Object()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.AreEqual(builder.Object, exec<ITestClass1>(builder).Object);
        }

        [Test]
        public void returns_registration_flags_count_biggest_than_was()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            int before = builder.Object.RegistrationFlags.Count;
            int after = exec<ITestClass1>(builder).Object.RegistrationFlags.Count;

            Assert.IsTrue(before < after);
        }

        [Test]
        public void returns_registration_flag_AsInterface()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.NotNull(exec<ITestClass1>(builder).Object.RegistrationFlags.FirstOrDefault(x => x.Code == RegistrationFlagConstants.AsInterface));
        }

        [Test]
        public void returns_registration_flag_AsInterface_has_not_null_value()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.NotNull(exec<ITestClass1>(builder).Object.RegistrationFlags.FirstOrDefault(x => x.Code == RegistrationFlagConstants.AsInterface).Value);
        }

        [Test]
        public void returns_registration_flag_AsInterface_value_is_assignable_to_IInterface()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            object rawValue = exec<ITestClass1>(builder).Object.RegistrationFlags.FirstOrDefault(x => x.Code == RegistrationFlagConstants.AsInterface).Value;

            Assert.IsTrue(rawValue is IInterface);
        }

        [Test]
        public void returns_registration_flag_AsInteface_IInterface_Type_equals_to_gived_interface()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            IInterface @interface = (IInterface) exec<ITestClass1>(builder).Object.RegistrationFlags
                .FirstOrDefault(x => x.Code == RegistrationFlagConstants.AsInterface).Value;
            Assert.AreEqual(typeof(ITestClass1), @interface.Type);
        }

        [Test]
        public void throws_InvalidOperationException_if_AsInterface_generic_argument_is_not_interface()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.That(() => exec<ItIsNotInterface>(builder), Throws.InvalidOperationException);
        }
    }
}