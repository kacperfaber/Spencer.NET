using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class readonlycontainer_resolveordefault_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }
        
        T exec<T>(IReadOnlyContainerResolver resolver)
        {
            return resolver.ResolveOrDefault<T>();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer();

            Assert.DoesNotThrow(() => exec<TestClass>(container));
        }

        [Test]
        public void returns_not_null_if_gived_type_was_registered()
        {
            IStorage storage = new StorageBuilder()
                .Register<TestClass>()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);
            
            Assert.IsNotNull(exec<TestClass>(container));
        }

        [Test]
        public void returns_null_if_gived_type_was_not_registered()
        {
            IStorage storage = new StorageBuilder()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);
            
            Assert.IsNull(exec<TestClass>(container));
        }

        [Test]
        public void returns_not_null_if_gived_type_was_interface()
        {
            IStorage storage = new StorageBuilder()
                .Register<TestClass>()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            Assert.NotNull(exec<ITestClass>(container));
        }

        [Test]
        public void returns_null_if_implementation_of_gived_interface_was_not_registered()
        {
            IStorage storage = new StorageBuilder()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            Assert.Null(exec<ITestClass>(container));
        }

        [Test]
        public void dont_throws_exceptions_if_gived_type_was_not_registered()
        {
            IStorage storage = new StorageBuilder()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            Assert.DoesNotThrow(() => exec<TestClass>(container));
        }
    }
}