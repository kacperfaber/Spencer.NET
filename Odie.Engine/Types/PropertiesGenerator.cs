using System;
using System.Collections.Generic;
using System.Reflection;
using Odie.Commons;

namespace Odie.Engine
{
    public class PropertiesGenerator : IPropertiesGenerator
    {
        public IPropertyInfosGetter PropertyInfosGetter;
        public IPropertyInfosFilter PropertyInfosFilter;

        public IEnumerable<Property> GenerateProperties(Type type)
        {
            using (PropertyBuilder builder = new PropertyBuilder())
            {
                IEnumerable<PropertyInfo> propertyInfos = PropertyInfosGetter.GetAll(type);
                IEnumerable<PropertyInfo> filteredPropertyInfos = PropertyInfosFilter.Filter(propertyInfos);

                foreach (PropertyInfo propertyInfo in filteredPropertyInfos)
                {
                    yield return builder
                        .LoadFrom(propertyInfo)
                        .Build();

                    builder.Clear();
                }
            }
        }
    }
}