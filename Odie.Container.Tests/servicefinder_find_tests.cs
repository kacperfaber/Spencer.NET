using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class servicefinder_find_tests
    {
        interface ITest1
        {
        }

        interface ITest2
        {
        }

        class Test1 : ITest1
        {
        }

        class Test2 : ITest2
        {
        }

        Service exec<TKey>()
        {
            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()), new TypeServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()), new ServiceRegistrationGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator())), new ServiceServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())), new ServiceInfoGenerator()));

            AssemblyList assemblies = new AssemblyList();
            Service test1 = generator.GenerateServices(typeof(Test1), assemblies).First();
            Service test2 = generator.GenerateServices(typeof(Test2), assemblies).First();

            ServicesList list = new ServicesList()
            {
                Services = new List<Service>()
                    {test1, test2}
            };

            ServiceFinder finder = new ServiceFinder(new TypeContainsGenericParametersChecker(), new GenericServiceFinder(new TypeGenericParametersProvider()),new ServiceByInterfaceFinder(), new ServiceByClassFinder(), new TypeIsClassValidator());
            return finder.Find(list, typeof(TKey));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITest1>());
        }

        [Test]
        public void returns_service_test1_if_gived_key_is_itest1()
        {
            Assert.AreEqual(typeof(Test1), exec<ITest1>().Registration.TargetType);
        }

        [Test]
        public void returns_service_test2_if_gived_key_is_itest2()
        {
            Assert.AreEqual(typeof(Test2), exec<ITest2>().Registration.TargetType);
        }
    }
}