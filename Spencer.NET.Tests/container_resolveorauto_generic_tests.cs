using System;
using System.Reflection;
using NUnit.Framework;
using Spencer.NET;

namespace Odie.Container.Tests
{
    public class container_resolveorauto_generic_tests
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
        
        T exec<T>(IContainerResolver container)
        {
            T result = container.ResolveOrAuto<T>();
            return result;
        }

        [Test]
        public void dont_throws_exceptions()
        {
            IContainer container = ContainerFactory.CreateContainer();
            Assert.DoesNotThrow(() => exec<TestClass>(container));
        }

        [Test]
        public void returns_not_null()
        {
            IContainer container = ContainerFactory.CreateContainer();
            Assert.NotNull(exec<TestClass>(container));
        }

        [Test]
        public void returns_instanceof_TestClass_if_target_was_TestClass()
        {
            IContainer container = ContainerFactory.CreateContainer();
            TestClass test = exec<TestClass>(container);

            Assert.AreEqual(typeof(TestClass), test.GetType());
        }

        [Test]
        public void returns_type_implements_ITestClass()
        {
            IContainer container = ContainerFactory.CreateContainer();
            TestClass test = exec<TestClass>(container);
            
            Assert.IsTrue(test is ITestClass);
        }

        [Test]
        public void returns_type_was_registered_in_container()
        {
            IContainer container = ContainerFactory.CreateContainer();
            bool hasBefore = container.Has<TestClass>();
            _ = exec<TestClass>(container);
         
            Assert.IsFalse(hasBefore);
            Assert.IsTrue(container.Has<TestClass>());
        }

        [Test]
        public void returns_type_was_registered_as_singleinstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            TestClass test = exec<TestClass>(container);
            TestClass test2 = exec<TestClass>(container);
            
            Assert.AreEqual(test, test2);
        }

        [Test]
        public void returns_type_was_registered_if_had_attribute_MultiInstance()
        {
            IContainer container = ContainerFactory.CreateContainer();
            bool hasBefore = container.Has<MultiInstance>();
            _ = exec<MultiInstance>(container);
         
            Assert.IsFalse(hasBefore);
            Assert.IsTrue(container.Has<MultiInstance>());
        }
        
        [Test]
        public void returns_type_was_registered_as_multiinstance_if_had_MultiInstance_attribute()
        {
            IContainer container = ContainerFactory.CreateContainer();
            MultiInstance test = exec<MultiInstance>(container);
            MultiInstance test2 = exec<MultiInstance>(container);
            
            Assert.AreNotEqual(test, test2);
        }
    }
}