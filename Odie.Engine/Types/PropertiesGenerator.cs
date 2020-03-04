using System;
using System.Collections.Generic;
using System.Reflection;
using Odie.Commons;

namespace Odie.Engine
{
    public class PropertiesGenerator : IPropertiesGenerator
    {
        public IPropertyInfosGetter PropertyInfosGetter;
        public object PropertyInfosFilter;

        public IEnumerable<Property> GenerateProperties(IEnumerable<ReflectionField> fields)
        {
            foreach (ReflectionField field in fields)
            {
                PropertyBuilder builder = new PropertyBuilder();
                builder.
            }
        }
    }
}