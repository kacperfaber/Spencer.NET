using System.Collections.Generic;
using Odie.Commons;

namespace Odie.Reflections
{
    public class PropertiesGenerator : IPropertiesGenerator
    {
        public IPropertyInfosGetter PropertyInfosGetter;

        public IEnumerable<Property> GenerateProperties(IEnumerable<ReflectionField> fields)
        {
            using PropertyBuilder builderExtension = new PropertyBuilder();
            
            foreach (ReflectionField field in fields)
            {
                yield return builderExtension
                    .LoadFrom(field)
                    .Build();

                builderExtension.Clear();
            }
        }
    }
}