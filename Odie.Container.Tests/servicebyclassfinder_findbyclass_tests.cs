using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class servicebyclassfinder_findbyclass_tests
    {
        interface ITest
        {
        }

        class DontRegister
        {
        }

        class Test1 : ITest
        {
        }

        class Test2
        {
        }
        
        IService exec<T>()
        {
            ServiceList list = new ServiceList();
            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()), new TypeServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder()), new ServiceFlagsIssuesResolver()), new ServiceRegistrationGenerator(new BaseTypeFinder(), new ServiceRegistrationInterfacesGenerator(new RegistrationInterfacesFilter(new NamespaceInterfaceValidator()),new TypeContainsGenericParametersChecker(), new TypeGenericParametersProvider(),new InterfaceGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())), new ServiceGenericRegistrationGenerator(new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker())), new ServiceInfoGenerator(),new ClassHasServiceFactoryChecker(), new ServiceFactoryProvider(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(), new ConstructorParametersGenerator(new TypedMemberValueProvider(new TypeIsValueTypeChecker(), new ValueTypeActivator(), new TypeIsArrayChecker(), new ArrayGenerator(), new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()), new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()), new ParameterHasDefaultValueChecker(), new ParameterDefaultValueProvider()), new ConstructorParameterByTypeFinder()), new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(),new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),new ConstructorInfoListGenerator(), new ConstructorFinder(),new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),new ParametersValuesExtractor()))), new ServiceFactoryInvoker()));

            IEnumerable<IService> services1 = generator.GenerateServices(typeof(Test1), new AssemblyList(), null);
            IEnumerable<IService> services2 = generator.GenerateServices(typeof(Test2), new AssemblyList(), null);

            foreach (IService service in services1)
            {
                list.AddService(service);
            }

            foreach (IService service in services2)
            {
                list.AddService(service);
            }

            ServiceByClassFinder finder = new ServiceByClassFinder();
            return finder.FindByClass(list, typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test1>());
        }

        [Test]
        public void returns_excepted_service_targettype_if_gived_type_is_test1()
        {
            Assert.AreEqual(typeof(Test1), exec<Test1>().Registration.TargetType);
        }

        [Test]
        public void returns_service_interfaces_count_equals_to_1_if_gived_type_is_test1()
        {
            Assert.IsTrue(exec<Test1>().Registration.Interfaces.Count() == 1);
        }
        
        [Test]
        public void returns_service_interfaces_count_equals_to_0_if_gived_type_is_test2()
        {
            Assert.IsTrue(!exec<Test2>().Registration.Interfaces.Any());
        }

        [Test]
        public void returns_null_if_gived_type_wasnt_registered()
        {
            Assert.Null(exec<DontRegister>());
        }
    }
}