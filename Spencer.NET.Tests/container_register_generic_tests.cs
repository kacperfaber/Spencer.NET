using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class container_register_generic_tests
    {
        interface ITest
        {
        }

        [AutoValue]
        class AutoValue : ITest
        {
        }

        class Generic : IGeneric<int, int>
        {
            public int X { get; set; } = 5;
            public int Y { get; set; } = -5;
        }

        interface IGeneric<T, T1>
        {
            int X { get; set; }
            
            int Y { get; set; }
        }

        void exec<T>(IContainerRegistrar registrar)
        {
            registrar.Register<T>();
        }

        [Test]
        public void dont_throws_exceptions_when_gived_was_AutoValue()
        {
            IContainer container = ContainerFactory.Container();

            Assert.DoesNotThrow(() => exec<AutoValue>(container));
        }

        [Test]
        public void container_storage_services_will_be_has_not_null_instance_if_registered_was_AutoValue()
        {
            IContainer container = ContainerFactory.Container();

            exec<AutoValue>(container);

            IService service = container.Storage.Services.GetServices().FirstOrDefault(x => x.Registration.TargetType == typeof(AutoValue));

            Assert.NotNull(service);
        }

        [Test]
        public void container_storage_services_lenght_willnt_be_equals_to_before()
        {
            IContainer container = ContainerFactory.Container();
            List<IService> services = container.Storage.Services.GetServices();

            int after = services.Count();

            exec<AutoValue>(container);

            int before = services.Count();

            Assert.IsFalse(after == before);
        }

        [Test]
        public void container_storage_services_contains_not_empty_interfaces_list_when_gived_is_AutoValue()
        {
            IContainer container = ContainerFactory.Container();
            exec<AutoValue>(container);

            IService service = container.Storage.Services.GetServices().FirstOrDefault(x => x.Registration.TargetType == typeof(AutoValue));
            
            Assert.IsNotEmpty(service.Registration.Interfaces);
        }

        [Test]
        public void container_can_resolve_AutoValue_class_with_not_null_value()
        {
            IContainer container = ContainerFactory.Container();
            exec<AutoValue>(container);
            
            Assert.NotNull(container.Resolve<AutoValue>());
        }

        [Test]
        public void dont_throws_exceptions_when_container_trying_to_resolve_AutoValue_by_generic_class()
        {
            IContainer container = ContainerFactory.Container();
            exec<AutoValue>(container);

            Assert.DoesNotThrow(() => container.Resolve<AutoValue>());
        }

        [Test]
        public void dont_throws_exceptions_when_container_trying_to_resolve_AutoValue_by_typeof_class()
        {
            IContainer container = ContainerFactory.Container();
            exec<AutoValue>(container);

            Assert.DoesNotThrow(() => container.Resolve(typeof(AutoValue)));
        }

        [Test]
        public void dont_throws_when_trying_to_register_type_implemented_generic_interface()
        {
            IContainer container = ContainerFactory.Container();
            Assert.DoesNotThrow(() => exec<Generic>(container));
        }
    }
}