using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class typeexisterchecker_check_tests
    {
        class Test1 : ITest1
        {
        }

        class Test2 : ITest2
        {
        }

        interface ITest1
        {
        }

        interface ITest2
        {
        }

        bool exec<T>()
        {
            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(new TypeImplementsInterfaceValidator()),
                new ServiceGenerator(new ServiceFlagsGenerator(new ServiceFlagsProvider(new AttributesFinder(),new MemberGenerator(new MemberFlagsGenerator())), new ServiceFlagsIssuesResolver()),
                    new ServiceRegistrationGenerator(new ServiceRegistrationFlagGenerator()),
                    new ServiceInfoGenerator(), new ClassHasServiceFactoryChecker(),
                    new ServiceFactoryProvider(new InstancesCreator(new ConstructorInstanceCreator(new ConstructorInvoker(),
                        new ConstructorParametersGenerator(new TypedMemberValueProvider(),new ConstructorParameterByTypeFinder(), new ServiceHasConstructorParametersChecker()), 
                        new ConstructorProvider(new ConstructorChecker(), new DefaultConstructorProvider(), new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),
                        new ConstructorInfoListGenerator(), new ConstructorFinder(), new ConstructorListGenerator(new ConstructorGenerator(new ParametersGenerator(new ParameterGenerator()))),new ParametersValuesExtractor()))), new ServiceFactoryInvoker()));
            IService test1Service = generator.GenerateServices(typeof(Test1), new AssemblyList(), null).First();

            ServiceList list = new ServiceList();
            list.AddService(test1Service);

            TypeExisterChecker checker = new TypeExisterChecker(new ServiceFinder(new TypeContainsGenericParametersChecker(), new GenericServiceFinder(new TypeIsClassValidator(), new GenericClassFinder(new TypeGenericParametersProvider()), new GenericInterfaceFinder(new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()), new InterfacesExtractor())), new ServiceByInterfaceFinder(new InterfacesExtractor(), new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer())), new ServiceByClassFinder(), new TypeIsClassValidator()));
            return checker.Check(list, typeof(T));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Test1>());
        }

        [Test]
        public void returns_true_if_gived_is_test1()
        {
            Assert.IsTrue(exec<Test1>());
        }

        [Test]
        public void returns_false_if_gived_is_test2()
        {
            Assert.IsFalse(exec<Test2>());
        }

        [Test]
        public void returns_true_if_gived_is_interface_of_test1()
        {
            Assert.IsTrue(exec<ITest1>());
        }

        [Test]
        public void returns_false_if_gived_is_interface_of_test2()
        {
            Assert.IsFalse(exec<ITest2>());
        }
    }
}