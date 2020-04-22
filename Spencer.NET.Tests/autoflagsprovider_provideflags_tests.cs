using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class autoflagsprovider_provideflags_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
            [Auto]
            public string Name { get; set; }
            
            [Auto]
            public string Email { get; set; } 
        }

        IEnumerable<ServiceFlag> exec()
        {
            Type type = typeof(TestClass);

            new ServiceBuilder()
                .AddFlags(new ServiceFlag("Name", null) {Member = new Member(){Instance = }});
                
            return new AutoFlagsProvider().ProvideFlags() 
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }
    }
}