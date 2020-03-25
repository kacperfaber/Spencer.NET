using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class valueprovider_providevalue_tests
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

        object exec<T>()
        {
            ValueProvider provider = new ValueProvider(new TypeIsValueTypeChecker(), new ValueTypeActivator(), new TypeIsArrayChecker(), new ArrayGenerator(),
                new IsEnumerableChecker(new GenericTypeGenerator(), new TypeGenericParametersProvider(), new TypeContainsGenericParametersChecker()),
                new EnumerableGenerator(new TypeGenericParametersProvider(), new GenericTypeGenerator()));

            return provider.ProvideValue(typeof(T), ContainerFactory.CreateContainer());
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<TestClass>());
        }

        [Test]
        public void returns_not_null()
        {
            object @class = exec<TestClass>();
            Assert.NotNull(@class);
        }
    }
}