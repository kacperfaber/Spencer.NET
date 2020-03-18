using System;
using System.Collections.Generic;
using NUnit.Framework;
using Odie.Commons;

namespace Odie.Tests
{
    public class tests
    {
        interface ITest
        {
        }

        class Test
        {
            public string x;
        }

        void exec()
        {
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }

        [Test]
        public void returnsx_x()
        {
            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()),
                new TypeServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(new BaseTypeFinder(),
                        new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator())),
                        new ServiceServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),
                    new ServiceInfoGenerator()));
            List<Service> services = new List<Service>(generator.GenerateServices(typeof(Service), new AssemblyList(), null));

            foreach (Service service in services)
            {
                Console.WriteLine(service.Registration.TargetType.Name);
            }
        }
    }
}