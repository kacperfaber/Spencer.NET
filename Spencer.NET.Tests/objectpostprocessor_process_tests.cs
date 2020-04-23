using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class objectpostprocessor_process_tests
    {
        class Pet
        {
            public string Name { get; set; }

            public Pet()
            {
            }

            public Pet(string name)
            {
                Name = name;
            }
        }

        class TestClass
        {
            [Inject]
            public Pet Pet { get; set; }

            [Instance]
            public static TestClass Instance { get; set; }
        }

        T exec<T>(IReadOnlyContainer container)
        {
            IServiceRegistration serviceRegistration = new ServiceRegistrationBuilder()
                .AddType(typeof(T))
                .AddBaseType(typeof(T).BaseType)
                .AddGenericRegistration(new ServiceGenericRegistration() {HasGenericParameters = false})
                .Build();

            ServiceFlags flags = new ServiceFlagsProvider(new AttributesFinder(), new MemberGenerator(new MemberFlagsGenerator())).ProvideFlags(typeof(T));

            IService service = new ServiceBuilder()
                .AddRegistration(serviceRegistration)
                .AddFlags(flags)
                .AddInfo(null)
                .Build();

            object instance = Activator.CreateInstance<T>();

            ObjectPostProcessor postProcessor = new ObjectPostProcessor(new InstanceMembersValueInjector(new MemberValueSetter(), new InstanceMembersFinder()),
                new MemberValuesInjector(new MemberValueSetter(), new TypedMemberValueProvider(), new InjectFlagsProvider(),
                    new MemberDeclarationTypeProvider()));
            
            postProcessor.Process(instance, service, container);

            return (T) instance;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Pet>();
            
            Assert.DoesNotThrow(() => exec<TestClass>(container));
        }

        [Test]
        public void returns_not_null()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Pet>();
            
            Assert.NotNull(exec<TestClass>(container));
        }

        [Test]
        public void returns_pet_with_inject_flags_not_null()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Pet>();

            Assert.NotNull(exec<TestClass>(container).Pet);
        }

        [Test]
        public void returns_pet_with_inject_flag_typeof_Pet()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Pet>();

            Assert.IsTrue(exec<TestClass>(container).Pet is Pet);
        }

        [Test]
        public void returns_pet_with_inject_flag_has_null_name()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Pet>();

            Assert.IsNull(exec<TestClass>(container).Pet.Name);
        }

        [TestCase("odie")]
        [TestCase("florka")]
        [TestCase("tobis")]
        public void returns_gived_pet_name_if_pet_was_registered_before_using_constructorparameters(string petName)
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Pet>(petName);
            container.Register<TestClass>();

            string name = exec<TestClass>(container).Pet.Name;

            Assert.AreEqual(petName, name);
        }

        [Test]
        public void TestClass_Instance_are_not_null_after_invoke_exec_method()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Pet>();
            container.Register<TestClass>();
            
            exec<TestClass>(container);

            Assert.NotNull(TestClass.Instance);
        }

        [Test]
        public void TestClass_Instance_are_equal_to_the_resolved_from_container()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Pet>();
            container.Register<TestClass>();
            
            TestClass excepted = exec<TestClass>(container);

            Assert.AreEqual(excepted, TestClass.Instance);
        }
    }
}