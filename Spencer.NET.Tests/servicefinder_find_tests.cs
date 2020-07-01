﻿using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
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

        IService exec<TKey>()
        {
            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(),
                ServiceGeneratorFactory.MakeInstance());

            AssemblyList assemblies = new AssemblyList();
            IService test1 = generator.GenerateServices(typeof(Test1), assemblies, null).First();
            IService test2 = generator.GenerateServices(typeof(Test2), assemblies, null).First();

            ServiceList list = new ServiceList();
            list.AddServices(test1, test2);

            ServiceFinder finder = new ServiceFinder(new TypeContainsGenericParametersChecker(),
                new GenericServiceFinder(new TypeIsClassValidator(), new GenericClassFinder(new TypeGenericParametersProvider()),
                    new GenericInterfaceFinder(new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()),
                        new InterfacesExtractor())),
                new ServiceByInterfaceFinder(new InterfacesExtractor(),
                    new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer())), new ServiceByClassFinder(),
                new TypeIsClassValidator());

            return finder.Find(list, typeof(TKey));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITest1>());
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec<ITest1>());
        }

        [Test]
        public void returns_service_test1_if_gived_key_is_itest1()
        {
            Assert.AreEqual(typeof(Test1), exec<ITest1>().Registration.TargetType);
        }

        [Test]
        public void returns_service_test2_if_gived_key_is_itest2()
        {
            IService service = exec<ITest2>();
            Assert.AreEqual(typeof(Test2), service.Registration.TargetType);
        }
    }
}