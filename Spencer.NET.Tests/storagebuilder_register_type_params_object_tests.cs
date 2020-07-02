using System;
using System.Linq;
using NUnit.Framework;
using Spencer.NET.Extensions;

namespace Spencer.NET.Tests
{
    public class storagebuilder_register_type_params_object_tests
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

        StorageBuilder exec(StorageBuilder builder, Type type, params object[] parameters)
        {
            return builder.Register(type, parameters);
        }

        [Test]
        public void dont_throws_exceptions_when_registering_class()
        {
            Assert.DoesNotThrow(() => exec(new StorageBuilder(), typeof(Single)));
        }

        [Test]
        public void dont_throws_exceptions_when_registering_interface()
        {
            Assert.DoesNotThrow(() => exec(new StorageBuilder(), typeof(ISingle)));
        }

        [Test]
        public void returns_Object_not_null()
        {
            Assert.NotNull(exec(new StorageBuilder(), typeof(Single)));
        }

        [Test]
        public void returns_same_Object_instance()
        {
            StorageBuilder builder = new StorageBuilder();
            Assert.AreEqual(builder.Object, exec(builder, typeof(Single)).Object);
        }

        [Test]
        public void returns_same_builder_instance()
        {
            StorageBuilder builder = new StorageBuilder();

            Assert.AreEqual(builder, exec(builder, typeof(Single)));
        }

        [Test]
        public void returns_builder_Object_has_greater_services_count_than_was()
        {
            StorageBuilder builder = new StorageBuilder();
            int before = builder.Object.Services.GetServices().Count;
            exec(builder, typeof(Single));
            int after = builder.Object.Services.GetServices().Count;

            Assert.IsTrue(before < after);
        }

        [TestCase(typeof(Single))]
        [TestCase(typeof(Multi))]
        [TestCase(typeof(Auto))]
        public void returns_Object_services_contains_service_of_gived_type(Type type)
        {
            StorageBuilder builder = new StorageBuilder();
            exec(builder, type);

            Assert.NotNull(builder.Object.Services.GetServices().SingleOrDefault(x => x.Registration.TargetType == type));
        }

        [Test]
        public void service_is_SingleInstance_if_type_was_flagged_as_SingleInstance()
        {
            StorageBuilder builder = new StorageBuilder();
            exec(builder, typeof(Single));

            IService service = builder.Object.Services.GetServices().SingleOrDefault(x => x.Registration.TargetType == typeof(Single));
            
            Assert.NotNull(service.Registration.RegistrationFlags.Has(RegistrationFlagConstants.IsSingleInstance));
        }
        
        [Test]
        public void service_is_MultiInstance_if_type_was_flagged_as_SingleInstance()
        {
            StorageBuilder builder = new StorageBuilder();
            exec(builder, typeof(Multi));

            IService service = builder.Object.Services.GetServices().SingleOrDefault(x => x.Registration.TargetType == typeof(Multi));
            
            Assert.NotNull(service.Registration.RegistrationFlags.Has(RegistrationFlagConstants.IsMultiInstance));
        }
    }
}