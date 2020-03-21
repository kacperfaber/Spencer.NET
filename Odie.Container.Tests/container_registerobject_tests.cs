using System;
using System.Linq;
using NUnit.Framework;

namespace Odie.Container.Tests
{
    public class container_registerobject_tests
    {
        interface ISingle
        {
        }

        interface IMulti
        {
        }

        class Single : ISingle
        {
            public string Name { get; set; }
        }

        [MultiInstance]
        class Multi : IMulti
        {
            public string Name { get; set; }
        }

        void exec(IContainerRegistrar registrar, object @object)
        {
            registrar.RegisterObject(@object);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(ContainerFactory.CreateContainer(), new Single()));
        }

        [Test]
        public void dont_throws_exception_when_gived_object_has_attribute_multiinstance()
        {
            Assert.DoesNotThrow(() => exec(ContainerFactory.CreateContainer(), new Multi()));
        }

        [Test]
        public void container_storage_after_exec_will_be_upper_than_was_and_object_is_multiinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            int was = container.Storage.Services.GetServices().Count();
            exec(container, new Multi());
            int now = container.Storage.Services.GetServices().Count();

            Assert.IsTrue(was < now);
        }

        [Test]
        public void container_storage_after_exec_will_be_upper_than_was_and_object_is_singleinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            int was = container.Storage.Services.GetServices().Count();
            exec(container, new Single());
            int now = container.Storage.Services.GetServices().Count();

            Assert.IsTrue(was < now);
        }

        [Test]
        public void container_storage_services_has_targettype_of_gived_object_singleinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            Single @object = new Single();

            exec(container, @object);

            Assert.NotNull(container.Storage.Services.GetServices().SingleOrDefault(x => x.Registration.TargetType == @object.GetType()));
        }

        [Test]
        public void container_storage_services_has_targettype_of_gived_object_multiinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            Multi @object = new Multi();

            exec(container, @object);

            Assert.NotNull(container.Storage.Services.GetServices().SingleOrDefault(x => x.Registration.TargetType == @object.GetType()));
        }

        [Test]
        public void created_service_has_no_null_instance_singleinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            object @object = new Single();

            exec(container, @object);

            IService service = container.Storage.Services.GetServices().SingleOrDefault(x => x.Registration.TargetType == @object.GetType());
            bool condition = service.Registration.Instance != null;

            Assert.IsTrue(condition);
        }

        [Test]
        public void created_service_has_no_null_instance_multiinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            object @object = new Multi();

            exec(container, @object);

            IService service = container.Storage.Services.GetServices().SingleOrDefault(x => x.Registration.TargetType == @object.GetType());
            bool condition = service.Registration.Instance != null;

            Assert.IsTrue(condition);
        }

        [Test]
        public void container_resolve_returns_not_null_of_singleinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            object @object = new Single();

            exec(container, @object);

            object instance = container.Resolve(@object.GetType());

            Assert.NotNull(instance);
        }

        [Test]
        public void container_resolve_returns_not_null_of_multiinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            object @object = new Multi();

            exec(container, @object);

            object instance = container.Resolve(@object.GetType());

            Assert.NotNull(instance);
        }

        [Test]
        public void container_resolve_returns_same_instance_if_gived_type_has_flag_singleinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            object @object = new Single();

            exec(container, @object);

            object instance = container.Resolve(@object.GetType());

            Assert.AreEqual(@object, instance);
        }

        [Test]
        public void container_resolve_returns_other_instance_if_gived_type_has_flag_multiinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            object @object = new Multi();

            exec(container, @object);

            object instance = container.Resolve(@object.GetType());

            Assert.AreNotEqual(@object, instance);
        }

        [Test]
        public void throws_exception_if_gived_instance_is_null()
        {
            Assert.Throws<NullReferenceException>(() => exec(ContainerFactory.CreateContainer(), null));
        }
    }
}