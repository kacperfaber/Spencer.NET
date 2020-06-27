using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class assemblyregistrationconverter_convert_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }
        
        IEnumerable<IService> exec(AssemblyRegistration registration)
        {
            IContainerRegistrationConverter<AssemblyRegistration> converter = new AssemblyRegistrationConverter();
            return converter.Convert(registration);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            AssemblyRegistration registration = new AssemblyRegistration()
            {
                Assembly = GetType().Assembly
            };
            
            new AssemblyRegistrationBuilder(registration)
                .IncludeClass<TestClass>()
                .SelectClass<TestClass>()
                .AsInterface<ITestClass>();
            
            Assert.DoesNotThrow(() => exec(registration));
        }

        [Test]
        public void returns_instance_of_IEnumerable_of_IService()
        {
            AssemblyRegistration registration = new AssemblyRegistration()
            {
                Assembly = GetType().Assembly
            };
            
            new AssemblyRegistrationBuilder(registration)
                .IncludeClass<TestClass>()
                .SelectClass<TestClass>()
                .AsInterface<ITestClass>();
            
            Assert.IsTrue(exec(registration) is IEnumerable<IService>);
        }

        [Test]
        public void returns_single_IService_if_gived_was_single_TestClass()
        {
            AssemblyRegistration registration = new AssemblyRegistration()
            {
                Assembly = GetType().Assembly
            };
            
            new AssemblyRegistrationBuilder(registration)
                .IncludeClass<TestClass>()
                .SelectClass<TestClass>()
                .AsInterface<ITestClass>();
            
            Assert.IsTrue(exec(registration).Count() == 1);
        }
    }
}