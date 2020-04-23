using NUnit.Framework;

namespace Spencer.NET.Tests
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
            TypedMemberValueProvider provider = new TypedMemberValueProvider();
            return provider.ProvideValue(typeof(T), container);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.Container();
            container.Register<Odie>();
            container.Register<TestClass>();
            
            Assert.DoesNotThrow(() => exec<TestClass>(container));
        }

        [Test]
        public void returns_not_null()
        {
            IContainer container = ContainerFactory.Container();
            container.Register<Odie>();
            container.Register<TestClass>();

            object @class = exec<TestClass>(container);
            Assert.NotNull(@class);
        }
    }
}