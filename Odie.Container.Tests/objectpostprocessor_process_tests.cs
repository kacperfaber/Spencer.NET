using System;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Odie.Container.Tests
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

        T exec<T>(IContainer container)
        {
            ServiceRegistration serviceRegistration = new ServiceRegistrationBuilder()
                .AddType(typeof(T))
                .AddBaseType(typeof(T).BaseType)
                .AddGenericRegistration(new ServiceGenericRegistration() {HasGenericParameters = false})
                .Build();

            ServiceFlags flags = new ServiceFlagsProvider(new AttributesFinder(), new MemberGenerator(new MemberFlagsGenerator())).ProvideFlags(typeof(T));

            Service service = new ServiceBuilder()
                .AddRegistration(serviceRegistration)
                .AddFlags(flags)
                .AddInfo(null)
                .Build();

            object instance = Activator.CreateInstance<T>();
            
            ObjectPostProcessor postProcessor = new ObjectPostProcessor(new InstanceMembersValueInjector(new MemberValueSetter(), new InstanceMembersFinder()), new MemberValuesInjector(new MemberValueSetter(), new TypedMemberValueProvider(new TypeIsValueTypeChecker(), new ValueTypeActivator(), new TypeIsArrayChecker(), new ArrayGenerator(), new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()), new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()), new ParameterHasDefaultValueChecker(), new ParameterDefaultValueProvider()), new InjectFlagsProvider(),new MemberDeclarationTypeProvider()));
            postProcessor.Process(instance, service, container);

            return (T) instance;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>(ContainerFactory.CreateContainer()));
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec<TestClass>(ContainerFactory.CreateContainer()));   
        }

        [Test]
        public void returns_pet_with_inject_flags_not_null()
        {
            Assert.NotNull(exec<TestClass>(ContainerFactory.CreateContainer()).Pet);
        }

        [Test]
        public void returns_pet_with_inject_flag_typeof_Pet()
        {
            Assert.IsTrue(exec<TestClass>(ContainerFactory.CreateContainer()).Pet is Pet);
        }

        [Test]
        public void returns_pet_with_inject_flag_has_null_name()
        {
            Assert.IsNull(exec<TestClass>(ContainerFactory.CreateContainer()).Pet.Name);
        }

        [TestCase("odie")]
        [TestCase("florka")]
        [TestCase("tobis")]
        public void returns_gived_pet_name_if_pet_was_registered_before_using_constructorparameters(string petName)
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Pet>(petName);

            string name = exec<TestClass>(container).Pet.Name;
            
            Assert.AreEqual(petName, name);
        }

        [Test]
        public void TestClass_Instance_are_not_null_after_invoke_exec_method()
        {
            exec<TestClass>(ContainerFactory.CreateContainer());
            
            Assert.NotNull(TestClass.Instance);
        }

        [Test]
        public void TestClass_Instance_are_equal_to_the_resolved_from_container()
        {
            TestClass excepted = exec<TestClass>(ContainerFactory.CreateContainer());
            
            Assert.AreEqual(excepted, TestClass.Instance);
        }
    }
}