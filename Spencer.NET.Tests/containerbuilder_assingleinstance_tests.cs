using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class containerbuilder_assingleinstance_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }
        
        ClassRegistrationBuilder exec(ClassRegistrationBuilder builder)
        {
            return builder.AsSingleInstance();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.DoesNotThrow(() => exec(builder));
        }

        [Test]
        public void returns_same_ClassRegistrationBuilder_instance()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.AreEqual(builder, exec(builder));
        }

        [Test]
        public void returns_same_ClassRegistrationBuilder_Object()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.AreEqual(builder.Object, exec(builder).Object);
        }

        [Test]
        public void returns_greater_flags_count_before_was()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            int before = builder.Object.RegistrationFlags.Count;
            exec(builder);
            int after = builder.Object.RegistrationFlags.Count;
            
            Assert.IsTrue(before < after);
        }

        [Test]
        public void returns_flags_contains_IsSingleInstance()
        {
            ClassRegistrationBuilder builder = new ContainerBuilder()
                .RegisterClass<TestClass>();

            Assert.NotNull(exec(builder).Object.RegistrationFlags.FirstOrDefault(x => x.Code == RegistrationFlagConstants.IsSingleInstance));
        }
    }
}