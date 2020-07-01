using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class genericinterfacefinder_findinterface_tests
    {
        class TestClass : ITest<int>, ITest<string>
        {
        }

        interface ITest<T>
        {
        }

        IService exec<T>()
        {
            TypedMemberValueProvider typedMemberValueProvider = new TypedMemberValueProvider();

            ServicesGenerator generator = new ServicesGenerator(new TypeIsClassValidator(), new ImplementationsFinder(),
                ServiceGeneratorFactory.MakeInstance());
            IService[] services = generator.GenerateServices(typeof(TestClass), new AssemblyList(), null).ToArray();

            ServiceList list = new ServiceList();
            list.AddServices(services);

            IService @interface = new GenericInterfaceFinder(new GenericTypesComparer(new TypeGenericParametersProvider(), new GenericArgumentsComparer()),
                    new InterfacesExtractor())
                .FindInterface(list,
                    typeof(T));

            return @interface;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<ITest<int>>());
            Assert.DoesNotThrow(() => exec<ITest<string>>());
        }

        [Test]
        public void returns_not_null_target_exist_generic_argument()
        {
            Assert.NotNull(exec<ITest<int>>());
            Assert.NotNull(exec<ITest<string>>());
        }

        [Test]
        public void returns_null_if_gived_generic_arguments_was_not_registered()
        {
            Assert.Null(exec<ITest<bool>>());
        }

        [Test]
        public void returns_interfaces_with_targettype_equals_to_TestClass()
        {
            bool b = exec<ITest<int>>().Registration.TargetType == typeof(TestClass);
            bool b2 = exec<ITest<string>>().Registration.TargetType == typeof(TestClass);

            Assert.IsTrue(b && b2);
        }

        [Test]
        public void returns_service_has_2_interfaces()
        {
            Assert.IsTrue(exec<ITest<int>>().Registration.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.AsInterface).Count() == 2);
            Assert.IsTrue(exec<ITest<string>>().Registration.RegistrationFlags.Where(x => x.Code == RegistrationFlagConstants.AsInterface).Count() == 2);
        }
    }
}