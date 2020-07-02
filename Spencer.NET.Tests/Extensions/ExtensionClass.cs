using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Spencer.NET.Tests.Extensions
{
    public static class ExtensionClass
    {
        public static void CheckFieldDependencies(this object @object)
        {
            Type objectType = @object.GetType();
            IEnumerable<FieldInfo> fields = objectType
                .GetFields()
                .Where(x => x.FieldType.IsInterface);

            foreach (FieldInfo field in fields)
            {
                object fieldValue = field.GetValue(@object);
                
                Assert.NotNull(fieldValue);
                
                fieldValue.CheckFieldDependencies();
                fieldValue.CheckPropertyDependencies();
            }
        }
        
        public static void CheckPropertyDependencies(this object @object)
        {
            Type objectType = @object.GetType();
            
            IEnumerable<PropertyInfo> properties = objectType
                .GetProperties()
                .Where(x => x.PropertyType.IsInterface);

            foreach (PropertyInfo property in properties)
            {
                object propertyValue = property.GetValue(@object);
                
                Assert.NotNull(propertyValue);
                
                propertyValue.CheckFieldDependencies();
                propertyValue.CheckPropertyDependencies();
            }
        }
    }
}