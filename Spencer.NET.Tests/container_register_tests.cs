using System;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class container_register_tests
    {
        interface ITestClass
        {
        }

        class Pet
        {
        }

        class TestClass : ITestClass
        {
            [Inject]
            public Pet Pet { get; set; }
        }

        void exec(IContainerRegistrar registrar, Type type)
        {
            registrar.Register(type);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.CreateContainer();

            Assert.DoesNotThrow(() => exec(container, typeof(TestClass)));
        }

        [Test]
        public void container_has_registered_type_after_registration()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.CreateContainer();
            bool before = container.Has(type);

            exec(container, type);

            bool after = container.Has(type);

            Assert.IsFalse(before);
            Assert.IsTrue(after);
        }

        [Test]
        public void container_resolve_dont_throws_if_injected_Pet_was_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.CreateContainer();
            container.Register(typeof(Pet));

            exec(container, type);

            Assert.DoesNotThrow(() => { container.Resolve(type); });
        }

        [Test]
        public void container_resolve_returns_not_null_if_target_and_injection_was_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.CreateContainer();
            container.Register(typeof(Pet));

            exec(container, type);

            Assert.NotNull(container.Resolve(type));
        }

        [Test]
        public void container_resolve_throws_exception_if_injections_was_not_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.CreateContainer();
            
            exec(container, type);

            Assert.Throws<Exception>(() => container.Resolve(typeof(TestClass)));
        }

        [Test]
        public void container_resolve_throws_InjectException_if_injections_was_not_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.CreateContainer();
            
            exec(container, type);

            Assert.Throws<InjectException>(() => container.Resolve(typeof(TestClass)));
        }
    }
}