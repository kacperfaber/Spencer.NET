using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class readonlycontainer_resolve_generic_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }
        
        T exec<T>(IReadOnlyContainer container)
        {
            return container.Resolve<T>();
        }

        [Test]
        public void throws_if_target_was_not_registered()
        {
            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer();

            Assert.That(() => exec<TestClass>(container), Throws.Exception);
        }

        [Test]
        public void returns_not_null_if_target_class_was_registered()
        {
            IStorage storage = new StorageBuilder()
                .Register<TestClass>()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            Assert.NotNull(exec<TestClass>(container));
        }

        [Test]
        public void returns_not_null_if_target_was_interface_of_registered_class()
        {
            IStorage storage = new StorageBuilder()
                .Register<TestClass>()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            Assert.NotNull(exec<ITestClass>(container));
        }

        [Test]
        public void returns_instanceof_TestClass_if_target_was_ITestClass()
        {
            IStorage storage = new StorageBuilder()
                .Register<TestClass>()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            Assert.IsInstanceOf<TestClass>(exec<ITestClass>(container));
        }

        [Test]
        public void dont_throws_if_target_was_registered_with_instance()
        {
            TestClass test = new TestClass();

            IStorage storage = new StorageBuilder()
                .RegisterObject(test)
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            Assert.DoesNotThrow(() => exec<TestClass>(container));
        }

        [Test]
        public void returns_same_instances_if_target_was_registered_with_instance()
        {
            TestClass test = new TestClass();

            IStorage storage = new StorageBuilder()
                .RegisterObject(test)
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);
            
            Assert.AreEqual(test, exec<TestClass>(container));
        }
    }
}