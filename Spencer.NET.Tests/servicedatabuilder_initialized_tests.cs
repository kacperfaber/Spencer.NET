using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class servicedatabuilder_initialized_tests
    {
        ServiceDataBuilder exec(ServiceDataBuilder builder, bool initialized)
        {
            return builder.Initialized(initialized);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(new ServiceDataBuilder(), false));
        }

        [Test]
        public void returns_same_builder_instance()
        {
            ServiceDataBuilder builder = new ServiceDataBuilder();

            Assert.AreEqual(builder, exec(builder, false));
        }

        [Test]
        public void returns_not_null_Object()
        {
            Assert.NotNull(exec(new ServiceDataBuilder(), false).Object);
        }

        [Test]
        public void returns_same_Object_instance()
        {
            ServiceDataBuilder builder = new ServiceDataBuilder();
            Assert.AreEqual(builder.Object, exec(builder, false).Object);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void returns_excepted_Object_Initialized_value(bool give)
        {
            ServiceDataBuilder builder = new ServiceDataBuilder();
            Assert.IsTrue(exec(builder, give).Object.Initialized == give);
        }
    }
}