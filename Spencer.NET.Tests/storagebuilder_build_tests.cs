using System.Linq;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class storagebuilder_build_tests
    {
        class TestClass
        {
        }
        
        object exec(StorageBuilder builder)
        {
            return builder.Build();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            StorageBuilder builder = new StorageBuilder();
            
            Assert.DoesNotThrow(() => exec(builder));
        }

        [Test]
        public void returns_instance_of_Storage()
        {
            StorageBuilder builder = new StorageBuilder(); 
            
            Assert.IsInstanceOf<Storage>(builder.Build());
        }

        [Test]
        public void returns_object_is_IStorage()
        {
            StorageBuilder builder = new StorageBuilder();
            
            Assert.IsTrue(builder.Build() is IStorage);
        }

        [Test]
        public void returns_not_null()
        {
            StorageBuilder builder = new StorageBuilder();
            
            Assert.NotNull(builder.Build());
        }

        [Test]
        public void returns_object_is_equals_to_builder_Object()
        {
            StorageBuilder builder = new StorageBuilder();
            
            Assert.AreEqual(builder.Object, builder.Build());
        }

        [Test]
        public void returns_excepted_services_count()
        {
            StorageBuilder builder = new StorageBuilder().Register<Tests.TestClass>().Register<TestClass>();
            
            Assert.IsTrue(builder.Build().Services.GetServices().Count() == 2);
        }
    }
}