using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class typedmembervalueprovider_providevalue_tests
    {
        class Odie
        {
        }

        class TestClass
        {
            public TestClass(Odie odie)
            {
            }
        }

        object exec<T>(IContainer container)
        {
            TypedMemberValueProvider provider = new TypedMemberValueProvider(new TypeIsValueTypeChecker(), new ValueTypeActivator(), new TypeIsArrayChecker(),
                new ArrayGenerator(),
                new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()),
                new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()), new ParameterHasDefaultValueChecker(),
                new ParameterDefaultValueProvider());


            return provider.ProvideValue(typeof(T), container);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Odie>();
            container.Register<TestClass>();
            
            Assert.DoesNotThrow(() => exec<TestClass>(container));
        }

        [Test]
        public void returns_not_null()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<Odie>();
            container.Register<TestClass>();

            object @class = exec<TestClass>(container);
            Assert.NotNull(@class);
        }
    }
}