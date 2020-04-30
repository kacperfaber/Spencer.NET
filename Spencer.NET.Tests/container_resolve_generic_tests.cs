using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class container_resolve_generic_tests
    {
        interface ITestClass
        {
        }

        interface ITestClass2
        {
        }

        class TestClass2 : ITestClass2
        {
        }

        class TestClass : ITestClass
        {
            public ITestClass2 TestClass2;
            
            public TestClass (ITestClass2 testClass2)
            {
                TestClass2 = testClass2;
            }
        }

        T exec<T>(IReadOnlyContainerResolver container)
        {
            T resolve = container.Resolve<T>();
            return resolve;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.Container();
            container.Register<TestClass>();
            
            Assert.DoesNotThrow(() => exec<TestClass>(container));
        }

        [Test]
        public void returns_not_null()
        {
            IContainer container = ContainerFactory.Container();
            container.Register<TestClass>();
            
            Assert.NotNull(exec<TestClass>(container));
        }

        [Test]
        public void returns_instance_of_TestClass_if_target_was_TestClass()
        {
            IContainer container = ContainerFactory.Container();
            container.Register<TestClass>();
            
            Assert.IsInstanceOf<TestClass>(exec<TestClass>(container));
        }

        [Test]
        public void returns_TestClass_TestClass2_not_null()
        {
            IContainer container = ContainerFactory.Container();
            container.Register<TestClass>();
            
            Assert.NotNull(exec<TestClass>(container).TestClass2);
        }

        [Test]
        public void returns_TestClass_TestClass2_is_instance_of_ITestClass2()
        {
            IContainer container = ContainerFactory.Container();
            container.Register<TestClass>();
            
            Assert.IsInstanceOf<TestClass2>(exec<TestClass>(container).TestClass2);
        }

        [Test]
        public void throws_if_TestClass_was_not_registered()
        {
            IContainer container = ContainerFactory.Container();

            Assert.Throws<ResolveException>(() => exec<TestClass>(container));
        }
    }
}