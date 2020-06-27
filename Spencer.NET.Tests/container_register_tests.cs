using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class container_register_tests
    {
        interface ITestClass
        {
        }

        class Animal
        {
        }

        class Pet
        {
        }

        class TestClass : ITestClass
        {
            [TryInject]
            public Animal Animal { get; set; }

            [Auto]
            public IEnumerable<int> Ints { get; set; }

            [Inject]
            public Pet Pet { get; set; }
        }

        [AutoValue]
        class AutoClass
        {
            public static int Instances = 0;

            public AutoClass()
            {
                Instances++;
            }
        }

        void exec(IContainerRegistrar registrar, Type type)
        {
            registrar.Register(type);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.Container();

            Assert.DoesNotThrow(() => exec(container, typeof(TestClass)));
        }

        [Test]
        public void container_has_registered_type_after_registration()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();
            bool before = container.Has(type);

            exec(container, type);

            bool after = container.Has(type);

            Assert.IsFalse(before);
            Assert.IsTrue(after);
        }

        [Test]
        public void container_resolve_throws_InjectException_if_injections_was_not_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();

            exec(container, type);

            Assert.Throws<InjectException>(() => container.Resolve(typeof(TestClass)));
        }

        [Test]
        public void container_resolve_dont_throws_if_injected_Pet_was_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();
            container.Register(typeof(Pet));

            exec(container, type);

            Assert.DoesNotThrow(() => { container.Resolve(type); });
        }

        [Test]
        public void container_resolve_returns_not_null_if_target_and_injection_was_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();
            container.Register(typeof(Pet));

            exec(container, type);

            Assert.NotNull(container.Resolve(type));
        }

        [Test]
        public void container_resolve_throws_exception_if_injections_was_not_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();

            exec(container, type);

            Assert.That(() => container.Resolve(typeof(TestClass)), Throws.Exception);
        }

        [Test]
        public void container_resolve_has_not_null_Auto_Ints_property()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();
            container.Register<Pet>();

            exec(container, type);

            Assert.NotNull(container.Resolve<TestClass>().Ints);
        }

        [Test]
        public void container_resolve_has_empty_Auto_Ints_property()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();
            container.Register<Pet>();

            exec(container, type);

            Assert.IsEmpty(container.Resolve<TestClass>().Ints);
        }

        [Test]
        public void container_resolve_dont_throws_if_TryInject_was_not_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();
            container.Register(typeof(Pet));

            exec(container, type);

            Assert.DoesNotThrow(() => { _ = container.Resolve<TestClass>(); });
        }

        [Test]
        public void container_resolve_has_null_TryInject_if_he_wasnt_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();
            container.Register<Pet>();

            exec(container, type);

            Assert.Null(container.Resolve<TestClass>().Animal);
        }

        [Test]
        public void container_resolve_has_not_null_TryInject_if_he_was_registered()
        {
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();
            container.Register<Pet>();
            container.Register(typeof(Animal));

            exec(container, type);

            Assert.NotNull(container.Resolve<TestClass>().Animal);
        }

        [Test]
        public void container_resolve_has_equals_TryInject_if_he_was_registered()
        {
            Animal animal = new Animal();
            Type type = typeof(TestClass);
            IContainer container = ContainerFactory.Container();
            container.Register<Pet>();
            container.RegisterObject(animal);

            exec(container, type);

            Assert.AreEqual(animal, container.Resolve<TestClass>().Animal);
        }

        [Test]
        public void dont_throws_exceptions_if_registering_class_is_AutoValue_class()
        {
            IContainerRegistrar container = ContainerFactory.Container();

            Assert.DoesNotThrow(delegate { exec(container, typeof(AutoClass)); });
        }

        [Test]
        public void AutoClass_Instances_is_1_after_registering_AutoClass_to_Container()
        {
            IContainer container = ContainerFactory.Container();
            
            exec(container, typeof(AutoClass));
            
            Assert.IsTrue(AutoClass.Instances == 1);
        }
    }
}