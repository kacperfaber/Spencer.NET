using System;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class containerfactory_container_tests
    {
        IContainer exec()
        {
            return ContainerFactory.Container();
        }

        [Test]
        public void dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => exec());
        }

        [Test]
        public void returns_not_null()
        {
            Assert.NotNull(exec());
        }

        [Test]
        public void returns_instance_of_Container()
        {
            Assert.IsTrue(exec() is Container);
        }

        [Test]
        public void returns_not_null_Storage()
        {
            Assert.NotNull(exec().Storage);
        }

        void check_dependencies(Type type, object value)
        {
            foreach (FieldInfo field in type.GetFields())
            {
                object fieldValue = field.GetValue(value);
                
                Assert.NotNull(fieldValue);

                check_dependencies(fieldValue.GetType(), fieldValue);
            }
        }

        [Test]
        public void returns_dependencies_not_null()
        {
            IContainer container = exec();
            
            check_dependencies(typeof(Container), container);
        }
    }
}