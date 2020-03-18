using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class PropertyInfosGetter : IPropertyInfosGetter
    {
        public IEnumerable<PropertyInfo> GetAll(Type type)
        {
            return type.GetProperties();
        }
    }
}