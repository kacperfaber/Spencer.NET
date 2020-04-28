using System;
using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class storagebuilder_register_tests
    {
        interface ITestClass
        {
        }

        class TestClass : ITestClass
        {
        }

        void exec(StorageBuilder builder, Type type)
        {
            builder.Register(type);
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec(new StorageBuilder(), typeof(TestClass)));
        }

        [Test]
        public void builder_has_Object_not_null()
        {
            StorageBuilder builder = new StorageBuilder();
            exec(builder, typeof(TestClass));
            
            Assert.NotNull(builder.Object);
        }

        [Test]
        public void builder_Object_is_instance_of_Storage()
        {
            StorageBuilder builder = new StorageBuilder();
            exec(builder, typeof(TestClass));
            
            Assert.IsInstanceOf<Storage>(builder.Object);
        }

        [Test]
        public void builder_Object_is_assignable_to_IStorage()
        {
            StorageBuilder builder = new StorageBuilder();
            exec(builder, typeof(TestClass));

            Assert.IsTrue(builder.Object is IStorage);
        }

        [Test]
        public void builder_Object_Services_not_null()
        {
            StorageBuilder builder = new StorageBuilder();
            exec(builder, typeof(TestClass));

            Assert.NotNull(builder.Object.Services);
        }

        [Test]
        public void builder_Object_Services_count_is_one()
        {
            StorageBuilder builder = new StorageBuilder();
            exec(builder, typeof(TestClass));

            Assert.IsTrue(builder.Object.Services.GetServices().Count() == 1);
        }

        [Test]
        public void builder_Object_Services_is_not_empty_after_Register()
        {
            StorageBuilder builder = new StorageBuilder();
            exec(builder, typeof(TestClass));

            Assert.IsNotEmpty(builder.Object.Services.GetServices());
        }

        [Test]
        public void builder_Object_Services_contains_TestClass()
        {
            Type testClassType = typeof(TestClass);
            
            StorageBuilder builder = new StorageBuilder();
            exec(builder, testClassType);

            Assert.NotNull(builder.Object.Services.GetServices().FirstOrDefault(x => x.Registration.TargetType == testClassType));
        }
    }
}