using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests
{
    public class autovalueattribute_tests
    {
        [Test]
        public void is_Attribute()
        {
            Assert.IsTrue(typeof(Attribute).IsAssignableFrom(typeof(AutoValueAttribute)));
        }

        [Test]
        public void is_ServiceFlagAttribute()
        {
            Assert.IsTrue(typeof(ServiceFlagAttribute).IsAssignableFrom(typeof(AutoValueAttribute)));
        }

        [Test]
        public void has_AttributeUsage()
        {
            Attribute attr = typeof(AutoValueAttribute).GetCustomAttribute(typeof(AttributeUsageAttribute));

            Assert.NotNull(attr);
        }

        [Test]
        public void is_valid_on_Class()
        {
            AttributeUsageAttribute attr = (AttributeUsageAttribute) typeof(AutoValueAttribute).GetCustomAttribute(typeof(AttributeUsageAttribute));

            Assert.IsTrue((attr.ValidOn & AttributeTargets.Class) != 0);
        }

        [Test]
        public void is_not_valid_on_another_of_Class()
        {
            AttributeUsageAttribute attr = (AttributeUsageAttribute) typeof(AutoValueAttribute).GetCustomAttribute(typeof(AttributeUsageAttribute));

            string[] names = typeof(AttributeTargets).GetEnumNames();

            foreach (string name in names)
            {
                AttributeTargets targets = Enum.Parse<AttributeTargets>(name);

                if (targets == AttributeTargets.Class)
                {
                    continue;
                }
                
                Assert.IsFalse(attr.ValidOn == targets);
            }
        }

        [Test]
        public void has_empty_constructor()
        {
            Assert.IsTrue(typeof(AutoValueAttribute).GetConstructors().Where(x => x.GetParameters().Length == 0).Any());
        }

        [Test]
        public void has_ServiceFlag_field()
        {
            Assert.NotNull(typeof(AutoValueAttribute).GetFields().SingleOrDefault(x => x.FieldType == typeof(ServiceFlag)));
        }

        [Test]
        public void ServiceFlag_field_is_not_null_after_using_empty_constructor()
        {
            AutoValueAttribute attr = new AutoValueAttribute();

            Assert.NotNull(attr.ServiceFlag);
        }

        [Test]
        public void ServiceFlag_Name_is_equal_to_ServiceFlagConstants_AutoValue()
        {
            AutoValueAttribute attr = new AutoValueAttribute();

            Assert.AreEqual(ServiceFlagConstants.AutoValue, attr.ServiceFlag.Name);
        }
    }
}