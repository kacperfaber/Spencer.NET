using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class injectvalueprovider_providevalue_tests
    {
        interface ITestClass
        {
        }

        [SingleInstance]
        class TestClass : ITestClass
        {
        }

        [MultiInstance]
        class MultiInstance
        {
        }

        object exec(Type type, IReadOnlyContainer container)
        {
            InjectValueProvider provider = new InjectValueProvider();
            return provider.ProvideValue(type, container);
        }

        [Test]
        public void dont_throws_exceptions_if_container_is_ReadOnlyContainer_and_gived_is_class()
        {
            Assert.DoesNotThrow(() => exec(typeof(TestClass), ContainerFactory.ReadOnlyContainer()));
        }

        [Test]
        public void dont_throws_exceptions_if_container_is_Container_and_gived_is_class()
        {
            Assert.DoesNotThrow(() => exec(typeof(TestClass), ContainerFactory.Container()));
        }

        [Test]
        public void returns_null_if_container_is_ReadOnlyContainer_and_class_was_not_registered()
        {
            Assert.Null(exec(typeof(TestClass), ContainerFactory.ReadOnlyContainer()));
        }

        [Test]
        public void returns_not_null_if_container_is_Container_and_class_was_not_registered()
        {
            Assert.Null(exec(typeof(TestClass), ContainerFactory.Container()));
        }

        [Test]
        public void returns_null_if_container_is_ReadOnlyContainer_and_interface_was_not_registered()
        {
            Assert.Null(exec(typeof(ITestClass), ContainerFactory.ReadOnlyContainer()));
        }

        [Test]
        public void returns_not_null_if_container_is_Container_and_interface_was_not_registered()
        {
            Assert.Null(exec(typeof(ITestClass), ContainerFactory.Container()));
        }

        [Test]
        public void returns_same_instance_if_class_was_registered_as_single_instance()
        {
            IStorage storage = new StorageBuilder()
                .Register<TestClass>()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);
            TestClass excepted = container.Resolve<TestClass>();

            Assert.AreEqual(excepted, exec(typeof(TestClass), container));
        }

        [Test]
        public void returns_another_instance_if_class_was_registered_as_multi_instance()
        {
            IStorage storage = new StorageBuilder()
                .Register<MultiInstance>()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);
            MultiInstance excepted = container.Resolve<MultiInstance>();

            Assert.AreNotEqual(excepted, exec(typeof(MultiInstance), container));
        }
    }
}