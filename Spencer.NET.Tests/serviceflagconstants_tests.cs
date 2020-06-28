using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class serviceflagconstants_tests
    {
        [Test]
        public void has_no_public_constructor()
        {
            Assert.IsEmpty(typeof(ServiceFlagConstants).GetConstructors().Where(x => x.IsPublic));
        }

        [Test]
        public void has_constants_fields()
        {
            Assert.IsNotEmpty(typeof(ServiceFlagConstants).GetFields());
        }

        [Test]
        public void has_constants_string_fields()
        {
            Assert.IsNotEmpty(typeof(ServiceFlagConstants).GetFields().Where(x => x.FieldType == typeof(string)));
        }

        [TestCase("AsBaseType")]
        [TestCase("AsImplementedInterfaces")]
        [TestCase("Instance")]
        [TestCase("MultiInstance")]
        [TestCase("SingleInstance")]
        [TestCase("AlwaysNew")]
        [TestCase("ExcludeType")]
        [TestCase("ServiceCtor")]
        [TestCase("ServiceFactory")]
        [TestCase("Inject")]
        public void has_excepted_flags(string fieldName)
        {
            FieldInfo field = typeof(ServiceFlagConstants)
                .GetFields()
                .SingleOrDefault(x => x.Name == fieldName);
            
            Assert.NotNull(field);
        }

        [TestCase("AsBaseType")]
        [TestCase("AsImplementedInterfaces")]
        [TestCase("Instance")]
        [TestCase("MultiInstance")]
        [TestCase("SingleInstance")]
        [TestCase("AlwaysNew")]
        [TestCase("ExcludeType")]
        [TestCase("ServiceCtor")]
        [TestCase("ServiceFactory")]
        [TestCase("Inject")]
        public void has_constant_values(string fieldName)
        {
            FieldInfo field = typeof(ServiceFlagConstants)
                .GetFields()
                .SingleOrDefault(x => x.Name == fieldName);

            Assert.NotNull(field.GetRawConstantValue());
        }

        [Test]
        public void is_not_Obsolete()
        {
            Assert.Null(typeof(ServiceFlagConstants).GetCustomAttribute(typeof(ObsoleteAttribute)));
        }
    }
}