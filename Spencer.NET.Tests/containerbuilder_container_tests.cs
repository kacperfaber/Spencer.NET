using System;
using System.Reflection;
using NUnit.Framework;
using Spencer.NET.Tests.Extensions;

namespace Spencer.NET.Tests
{
    public class containerbuilder_container_tests
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
        }

        IContainer exec(ContainerBuilder builder)
        {
            return builder.Container();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(new ContainerBuilder()));
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec(new ContainerBuilder()));
        }

        [Test]
        public void returns_instance_of_Container()
        {
            Assert.IsTrue(exec(new ContainerBuilder()) is Container);
        }

        [Test]
        public void returns_Container_Storage_not_null()
        {
            ContainerBuilder builder = new ContainerBuilder();

            Assert.NotNull(exec(builder).Storage);
        }

        [Test]
        public void returns_same_Storage_instance()
        {
            ContainerBuilder builder = new ContainerBuilder();
            Assert.AreEqual(builder.StorageBuilder.Object, exec(builder).Storage);
        }

        [Test]
        public void returns_excepted_services_count_equals_to_StorageBuilder_Object_Services()
        {
            ContainerBuilder builder = new ContainerBuilder();

            Assert.IsTrue(builder.StorageBuilder.Object.Services.GetServices().Count == exec(builder).Storage.Services.GetServices().Count);
        }

        [TestCase(typeof(Single))]
        [TestCase(typeof(Multi))]
        [TestCase(typeof(Auto))]
        public void returns_Container_has_registered_types(Type type)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder
                .GetType()
                .GetMethod("RegisterClass")
                .MakeGenericMethod(type)
                .Invoke(builder, new object[] {});

            IContainer container = builder.Container();

            Assert.IsTrue(container.Has(type));
        }
    }
}