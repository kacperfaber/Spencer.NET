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

        object exec<T>(IReadOnlyContainer container)
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

        [Test]
        public void returns_null_if_container_is_ReadOnlyContainer()
        {
            IStorage storage = new StorageBuilder()
                .Register<TestClass>()
                .Build();
            
            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);
            object res = exec<Odie>(container);
            
            Assert.Null(res);
        }

        [Test]
        public void returns_not_null_if_container_is_ReadOnlyContainer_but_class_was_registered()
        {
            IStorage storage = new StorageBuilder()
                .Register<Odie>()
                .Build();
            
            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);
            object res = exec<Odie>(container);
            
            Assert.NotNull(res);
        }

        [Test]
        public void returns_excepted_instance_if_container_is_ReadOnlyContainer_but_class_was_registered_with_instance()
        {
            Odie odie = new Odie();

            IStorage storage = new StorageBuilder()
                .RegisterObject(odie)
                .Build();
            
            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);
            object res = exec<Odie>(container);
            
            Assert.AreEqual(odie, res);
        }
    }
}