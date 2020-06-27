using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class classesregistration_tests
    {
        [Test]
        public void ClassesRegistration_is_IContainerRegistration()
        {
            Assert.IsTrue(typeof(IContainerRegistration).IsAssignableFrom(typeof(ClassesRegistration)));
        }

        [Test]
        public void ClassesRegistration_has_List_of_ClassRegistration()
        {
            Assert.IsTrue(typeof(ClassesRegistration).GetProperties().Where(x => x.PropertyType == typeof(List<ClassRegistration>)).Any());
        }

        [Test]
        public void ClassesRegistration_List_of_ClassRegistration_name_if_ClassRegistrations()
        {
            PropertyInfo property = typeof(ClassesRegistration)
                .GetProperties()
                .Where(x => x.PropertyType == typeof(List<ClassRegistration>))
                .SingleOrDefault(x => x.Name == "ClassRegistrations");
            
            Assert.NotNull(property);
        }

        [Test]
        public void ClassesRegistration_List_of_ClassRegistration_is_public()
        {
            PropertyInfo property = typeof(ClassesRegistration)
                .GetProperties()
                .Where(x => x.PropertyType == typeof(List<ClassRegistration>))
                .SingleOrDefault(x => x.Name == "ClassRegistrations");

            Assert.IsTrue(property.GetGetMethod().IsPublic);
            Assert.IsTrue(property.GetSetMethod().IsPublic);
        }

        [Test]
        public void ClassesRegistration_is_public_class()
        {
            Type @class = typeof(ClassesRegistration);
            
            Assert.IsTrue(@class.IsPublic);
        }

        [Test]
        public void ClassesRegistration_has_not_parametrized_constructor()
        {
            Type @class = typeof(ClassesRegistration);

            Assert.IsTrue(@class.GetConstructors().Where(x => x.GetParameters().Length == 0).Any());
        }

        [Test]
        public void empty_constructor_dont_throws_exceptions()
        {
            Assert.DoesNotThrow(() => _ = new ClassesRegistration());
        }

        [Test]
        public void ClassesRegistration_is_not_Obsolete()
        {
            Type @class = typeof(ClassesRegistration);

            IEnumerable<Attribute> attributes = @class.GetCustomAttributes(typeof(ObsoleteAttribute));
            
            Assert.IsEmpty(attributes);
        }
        
        [Test]
        public void ClassesRegistration_List_of_ClassRegistration_is_not_null_after_object_initialization()
        {
            Assert.NotNull(new ClassesRegistration().ClassRegistrations);
        }
    }
}