using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class servicedatabuilder_addinstance_tests
    {
        ServiceDataBuilder exec(ServiceDataBuilder builder, object instance)
        {
            return builder.AddInstance(instance);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(new ServiceDataBuilder(), null));
        }

        [Test]
        public void returns_same_builder_instance()
        {
            ServiceDataBuilder builder = new ServiceDataBuilder();

            Assert.AreEqual(builder, exec(builder, null));
        }

        [Test]
        public void returns_not_null_Object()
        {
            Assert.NotNull(exec(new ServiceDataBuilder(), null).Object);
        }

        [Test]
        public void returns_same_Object_instance()
        {
            ServiceDataBuilder builder = new ServiceDataBuilder();
            Assert.AreEqual(builder.Object, exec(builder, null).Object);
        }

        [Test]
        public void returns_Object_Instance_are_equals_to_gived_instance()
        {
            object obj = new object();
            ServiceDataBuilder builder = new ServiceDataBuilder();
            Assert.AreEqual(obj, exec(builder, obj).Object.Instance);
        }
    }
}