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
    }
}