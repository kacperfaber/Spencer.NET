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

        IService exec<TKey>()
        {
            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()),
                new TypeServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(new BaseTypeFinder(),
                        new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()),new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(),new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),
                        new ServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())),
                    new ServiceInfoGenerator(), new ClassHasServiceFactoryChecker(),
                    new ServiceFactoryProvider(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                        new ConstructorParametersGenerator(new ParameterInfoDefaultValueProvider(), new ParameterHasDefaultValueChecker(),
                            new ValueTypeActivator(), new TypeIsValueTypeChecker(),new ConstructorParameterByTypeFinder()),
                        new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(),new ConstructorGenerator()),new ConstructorInfoListGenerator(), new ConstructorFinder(),new ConstructorListGenerator()))), new ServiceFactoryInvoker()));

            AssemblyList assemblies = new AssemblyList();
            IService test1 = generator.GenerateServices(typeof(Test1), assemblies, null).First();
            IService test2 = generator.GenerateServices(typeof(Test2), assemblies, null).First();

            ServiceList list = new ServiceList();
            list.AddServices(test1, test2);

            ServiceFinder finder = new ServiceFinder(new TypeContainsGenericParametersChecker(), new GenericServiceFinder(new TypeIsClassValidator(), new GenericClassFinder(new TypeGenericParametersProvider()), new GenericInterfaceFinder(new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()))),
                new ServiceByInterfaceFinder(), new ServiceByClassFinder(), new TypeIsClassValidator());
            
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