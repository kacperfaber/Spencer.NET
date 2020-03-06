using System;
using System.Collections.Generic;
using System.Reflection;
using Odie.Commons;

namespace Odie.Engine
{
    public class PropertiesGenerator : IPropertiesGenerator
    {
        public IPropertyInfosGetter PropertyInfosGetter;

        public IEnumerable<Property> GenerateProperties(IEnumerable<ReflectionField> fields)
        {
            using PropertyBuilder builder = new PropertyBuilder();
            
            foreach (ReflectionField field in fields)
            {
                yield return builder
                    .LoadFrom(field)
                    .Build();

                builder.Clear();
            }
        }
    }
}