using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class container_tests
    {
        [Test]
        public void is_IContainer()
        {
            Assert.IsTrue(typeof(IContainer).IsAssignableFrom(typeof(Container)));
        }

        [Test]
        public void is_ReadOnlyContainer()
        {
            Assert.IsTrue(typeof(ReadOnlyContainer).IsAssignableFrom(typeof(Container)));
        }

        [Test]
        public void has_strong_parametrized_constructor()
        {
            IEnumerable<ConstructorInfo> constructors = typeof(Container).GetConstructors().Where(x => x.GetParameters().Length > 1);

            Assert.IsNotEmpty(constructors);
        }

        [Test]
        public void has_no_dispose_pattern()
        {
            Assert.IsFalse(typeof(IDisposable).IsAssignableFrom(typeof(Container)));
        }

        [Test]
        public void is_not_Obsolete()
        {
            Assert.IsNull(typeof(Container).GetCustomAttribute(typeof(ObsoleteAttribute)));
        }

        [Test]
        public void has_storage_property()
        {
            PropertyInfo storageProperty = typeof(Container).GetProperties().SingleOrDefault(x => x.PropertyType == typeof(IStorage));

            Assert.NotNull(storageProperty);
        }

        [Test]
        public void storage_property_name_is_Storage()
        {
            PropertyInfo storageProperty = typeof(Container).GetProperties().SingleOrDefault(x => x.PropertyType == typeof(IStorage));

            Assert.AreEqual("Storage", storageProperty.Name);
        }

        [Test]
        public void storage_property_is_virtual()
        {
            PropertyInfo storageProperty = typeof(Container).GetProperties().SingleOrDefault(x => x.PropertyType == typeof(IStorage));

            Assert.IsTrue(storageProperty.GetGetMethod().IsVirtual);
        }
    }
}