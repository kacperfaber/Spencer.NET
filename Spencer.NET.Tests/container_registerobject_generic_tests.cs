using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class container_registerobject_generic_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }

        interface ITestClass2
        {
        }

        [MultiInstance]
        class TestClass2 : ITestClass2
        {
        }

        void exec<T>(IContainerRegistrar container, T instance)
        {
            container.RegisterObject<T>(instance);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainerRegistrar container = ContainerFactory.Container();
            Assert.DoesNotThrow(() => exec(container, new TestClass()));
        }

        [Test]
        public void resolve_registered_TestClass_dont_throws_exception()
        {
            IContainer container = ContainerFactory.Container();
            TestClass test = new TestClass();
            exec(container, test);

            Assert.DoesNotThrow(() => container.Resolve<TestClass>());
        }

        [Test]
        public void resolve_returns_equals_instance_if_TestClass_is_SingleInstance()
        {
            IContainer container = ContainerFactory.Container();
            TestClass test = new TestClass();
            exec(container, test);

            Assert.AreEqual(test, container.Resolve<TestClass>());
        }

        [Test]
        public void resolve_returns_another_instance_if_TestClass2_is_MultiInstance()
        {
            IContainer container = ContainerFactory.Container();
            TestClass2 test = new TestClass2();
            exec(container, test);
 
            Assert.AreNotEqual(test, container.Resolve<TestClass2>());
        }
    }
}