using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class container_resolveordefault_generic_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }

        interface IMultiInstance
        {
        }

        [MultiInstance]
        class MultiInstance : IMultiInstance
        {
        }
        
        T exec<T>(IContainerResolver resolver)
        {
            return resolver.ResolveOrDefault<T>();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<TestClass>();
            
            Assert.DoesNotThrow(() => exec<TestClass>(container));
        }

        [Test]
        public void returns_null_if_target_was_not_registered_TestClass()
        {
            IContainer container = ContainerFactory.CreateContainer();
            
            Assert.Null(exec<TestClass>(container));
        }

        [Test]
        public void returns_not_null_if_target_was_registered()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<TestClass>();
            
            Assert.NotNull(exec<TestClass>(container));
        }

        [Test]
        public void returns_same_object_if_target_was_registered_as_SingleInstance()
        {
            TestClass test = new TestClass();
            
            IContainer container = ContainerFactory.CreateContainer();
            container.RegisterObject(test);

            TestClass resolved = exec<TestClass>(container);
            
            Assert.AreEqual(test, resolved);
        }

        [Test]
        public void returns_not_null_if_target_was_registered_as_MultiInstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            container.Register<MultiInstance>();
            
            Assert.NotNull(exec<MultiInstance>(container));
        }

        [Test]
        public void returns_another_instances_if_target_was_registered_as_MultiInstance()
        {
            MultiInstance multiInstance = new MultiInstance();
            
            IContainer container = ContainerFactory.CreateContainer();
            container.RegisterObject(multiInstance);

            MultiInstance resolved = exec<MultiInstance>(container);
            
            Assert.AreNotEqual(multiInstance, resolved);
        }
    }
}