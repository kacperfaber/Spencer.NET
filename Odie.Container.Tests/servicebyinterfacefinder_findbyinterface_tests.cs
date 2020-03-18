using System.Collections.Generic;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class servicebyinterfacefinder_findbyinterface_tests
    {
        interface ITest
        {
        }

        interface IDontRegister
        {
        }

        class Test1 : ITest
        {
        }

        class Test2
        {
        }

        Service exec<T>()
        {
            ServicesList list = new ServicesList();
            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()),
                new TypeServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(new BaseTypeFinder(),
                        new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator())),
                        new ServiceServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),
                    new ServiceInfoGenerator()));

            IEnumerable<Service> services1 = generator.GenerateServices(typeof(Test1), new AssemblyList(), null);
            IEnumerable<Service> services2 = generator.GenerateServices(typeof(Test2), new AssemblyList(), null);

            foreach (Service service in services1)
            {
                list.AddService(service);
            }

            foreach (Service service in services2)
            {
                list.AddService(service);
            }

            ServiceByInterfaceFinder finder = new ServiceByInterfaceFinder();
            return finder.FindByInterface(list, typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITest>());
        }

        [Test]
        public void returns_service_with_test1_if_gived_interface_is_itest()
        {
            Assert.AreEqual(typeof(Test1), exec<ITest>().Registration.TargetType);
        }

        [Test]
        public void returns_null_if_gived_type_isnt_registered()
        {
            Assert.Null(exec<IDontRegister>());
        }
    }
}