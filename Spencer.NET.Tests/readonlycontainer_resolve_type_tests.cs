using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class readonlycontainer_resolve_type_tests
    {
        interface ISingle
        {
        }

        class Single : ISingle
        {
        }

        [MultiInstance]
        class Multi
        {
        }

        [AutoValue]
        class Auto
        {
        }

        object exec(IReadOnlyContainerResolver container, Type type)
        {
            return container.Resolve(type);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IStorage storage = new StorageBuilder()
                .Register(typeof(Single))
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            Assert.DoesNotThrow(() => exec(container, typeof(Single)));
        }

        [TestCase(typeof(Single))]
        [TestCase(typeof(Multi))]
        [TestCase(typeof(Auto))]
        public void returns_not_null_if_target_class_was_registered(Type type)
        {
            IStorage storage = new StorageBuilder()
                .Register(type)
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            Assert.NotNull(exec(container, type));
        }

        [TestCase(typeof(Single))]
        [TestCase(typeof(Multi))]
        [TestCase(typeof(Auto))]
        public void returns_instances_of_excepted_types_if_class_was_registered(Type type)
        {
            IStorage storage = new StorageBuilder()
                .Register(type)
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);
            object result = exec(container, type);

            Assert.IsTrue(type.IsInstanceOfType(result));
        }

        [TestCase(typeof(Single))]
        [TestCase(typeof(Multi))]
        [TestCase(typeof(Auto))]
        public void throws_ResolveException_if_target_class_was_not_registered(Type type)
        {
            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer();

            Assert.That(() => exec(container, type), Throws.InstanceOf<ResolveException>());
        }

        [Test]
        public void returns_same_instance_of_excepted_if_target_class_is_Single()
        {
            Single instance = new Single();

            IStorage storage = new StorageBuilder()
                .RegisterObject(instance)
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            Assert.AreEqual(instance, exec(container, typeof(Single)));
        }

        [Test]
        public void returns_same_instance_every_time_if_class_was_registered_as_SingleInstance()
        {
            IStorage storage = new StorageBuilder()
                .Register<Single>()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            object instance = exec(container, typeof(Single));

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(instance, exec(container, typeof(Single)));
            }
        }

        [Test]
        public void returns_new_instance_if_always_time_if_target_class_was_registered_as_MultiInstance()
        {
            IStorage storage = new StorageBuilder()
                .Register<Multi>()
                .Build();

            IReadOnlyContainer container = ContainerFactory.ReadOnlyContainer(storage);

            object instance = exec(container, typeof(Multi));

            for (int i = 0; i < 5; i++)
            {
                Assert.AreNotEqual(instance, exec(container, typeof(Multi)));
            }
        }
    }
}