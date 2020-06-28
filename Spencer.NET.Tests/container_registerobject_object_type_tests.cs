using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class container_registerobject_object_type_tests
    {
        interface ISingle
        {
        }

        class Single : ISingle
        {
        }

        interface IMulti
        {
        }

        [MultiInstance]
        class Multi : IMulti
        {
        }

        [AutoValue]
        class Auto
        {
        }

        [SingleInstance]
        class Ctor
        {
            public static int Instances;
            
            public Ctor()
            {
                Instances++;
            }
        }

        void exec(IContainerRegistrar registrar, object instance, Type type)
        {
            registrar.RegisterObject(instance, type);
        }

        [Test]
        public void dont_throws_exceptions_if_class_was_SingleInstance()
        {
            IContainer container = ContainerFactory.Container();
            Assert.DoesNotThrow(() => exec(container, new Single(), typeof(Single)));
        }

        [Test]
        public void dont_throws_exceptions_if_class_was_MultiInstance()
        {
            IContainer container = ContainerFactory.Container();
            Assert.DoesNotThrow(() => exec(container, new Multi(), typeof(Multi)));
        }

        [Test]
        public void container_storage_Services_has_more_than_before_registration()
        {
            IContainer container = ContainerFactory.Container();
            int before = container.Storage.Services.GetServices().Count;
            exec(container, new Single(), typeof(Single));
            int after = container.Storage.Services.GetServices().Count;

            Assert.IsTrue(before < after);
        }

        [Test]
        public void container_storage_Services_has_one_more_than_before_registration()
        {
            IContainer container = ContainerFactory.Container();
            int before = container.Storage.Services.GetServices().Count;
            exec(container, new Single(), typeof(Single));
            int after = container.Storage.Services.GetServices().Count;

            Assert.IsTrue(before + 1 == after);
        }

        [Test]
        public void container_resolve_returns_instance_if_she_was_SingleInstance()
        {
            Single instance = new Single();

            IContainer container = ContainerFactory.Container();
            exec(container, instance, typeof(Single));

            Assert.AreEqual(instance, container.Resolve<Single>());
        }

        [Test]
        public void container_resolve_returns_another_instance_if_she_was_MultiInstance()
        {
            Multi instance = new Multi();

            IContainer container = ContainerFactory.Container();
            exec(container, instance, typeof(Multi));

            Assert.AreNotEqual(instance, container.Resolve<Multi>());
        }

        [Test]
        public void dont_throws_exceptions_if_registering_instance_if_AutoValue()
        {
            Assert.DoesNotThrow(() => exec(ContainerFactory.Container(), new Auto(), typeof(Auto)));
        }

        [Test]
        public void returns_same_instance_if_class_was_AutoValue()
        {
            Auto instance = new Auto();

            IContainer container = ContainerFactory.Container();
            exec(container, instance, typeof(Auto));

            Assert.AreEqual(instance, container.Resolve<Auto>());
        }

        [Test]
        public void dont_using_constructor_if_instance_was_provided()
        {
            Ctor ctor = new Ctor();

            IContainer container = ContainerFactory.Container();
            exec(container, ctor, typeof(Ctor));

            if (Ctor.Instances == 1)
            {
                Assert.Pass();
            }
            
            Assert.Fail();
        }
    }
}