using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class storagebuilder_register_type_tests
    {
        class Single
        {
        }

        [MultiInstance]
        class Multi
        {
        }

        [AutoValue]
        class Auto
        {
            public Auto()
            {
                Assert.Pass();
            }
        }

        StorageBuilder exec<TRegistration>(StorageBuilder builder)
        {
            return builder.Register(typeof(TRegistration));
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec<Single>(new StorageBuilder()));
        }

        [Test]
        public void dont_throws_exceptions_when_registraion_is_MultiInstance()
        {
            Assert.DoesNotThrow(() => exec<Multi>(new StorageBuilder()));
        }

        [Test]
        public void dont_throws_exceptions_when_registration_is_AutoValue()
        {
            Assert.DoesNotThrow(() => exec<Auto>(new StorageBuilder()));
        }

        [Test]
        public void returns_same_StorageBuilder_instance()
        {
            StorageBuilder builder = new StorageBuilder();
            Assert.AreEqual(builder, exec<Single>(builder));
        }

        [Test]
        public void returns_same_StorageBuilder_Object()
        {
            StorageBuilder builder = new StorageBuilder();
            Assert.AreEqual(builder.Object, exec<Single>(builder).Object);
        }

        [TestCase(typeof(Single))]
        [TestCase(typeof(Multi))]
        [TestCase(typeof(Auto))]
        public void StorageBuilder_services_is_greater_than_was_before_registration(Type registrationType)
        {
            StorageBuilder builder = new StorageBuilder();
            int before = builder.Object.Services.GetServices().Count;

            object result = GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.ContainsGenericParameters)
                .FirstOrDefault(x => x.Name == "exec")
                .MakeGenericMethod(registrationType)
                .Invoke(this, new object[] {builder});

            int after = builder.Object.Services.GetServices().Count;

            Assert.IsTrue(after > before);
        }

        [TestCase(typeof(Single))]
        [TestCase(typeof(Multi))]
        [TestCase(typeof(Auto))]
        public void StorageBuilder_services_is_greater_one_than_was_before_registration(Type registrationType)
        {
            StorageBuilder builder = new StorageBuilder();
            int before = builder.Object.Services.GetServices().Count;

            object result = GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.ContainsGenericParameters)
                .FirstOrDefault(x => x.Name == "exec")
                .MakeGenericMethod(registrationType)
                .Invoke(this, new object[] {builder});

            int after = builder.Object.Services.GetServices().Count;

            Assert.IsTrue(after - 1 == before);
        }

        [TestCase(typeof(Single))]
        [TestCase(typeof(Multi))]
        [TestCase(typeof(Auto))]
        public void StorageBuilder_Object_contains_service_of_gived_class(Type registrationType)
        {
            StorageBuilder builder = new StorageBuilder();

            object result = GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.ContainsGenericParameters)
                .FirstOrDefault(x => x.Name == "exec")
                .MakeGenericMethod(registrationType)
                .Invoke(this, new object[] {builder});

            IService service = builder.Build().Services.GetServices().SingleOrDefault(x => x.Registration.TargetType == registrationType);
            
            Assert.NotNull(service);
        }
    }
}