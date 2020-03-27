using System;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class objectpostprocessor_process_tests
    {
        class Pet
        {
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
                .AddInstance(null).Build();

            ServiceFlags flags = new ServiceFlagsProvider(new AttributesFinder(), new MemberGenerator(new MemberFlagsGenerator())).ProvideFlags(typeof(T));

            Service service = new ServiceBuilder()
                .AddRegistration(serviceRegistration)
                .AddFlags(flags)
                .AddInfo(null)
                .Build();

            object instance = Activator.CreateInstance<T>();
            
            ObjectPostProcessor postProcessor = new ObjectPostProcessor(new InstanceMembersValueInjector(new MemberValueSetter(), new InstanceMembersFinder()), new MemberValuesInjector(new MemberValueSetter(), new TypedMemberValueProvider(new TypeIsValueTypeChecker(), new ValueTypeActivator(), new TypeIsArrayChecker(), new ArrayGenerator(), new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()), new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()), new ParameterHasDefaultValueChecker(), new ParameterDefaultValueProvider()), new InjectFlagsProvider()));
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
    }
}