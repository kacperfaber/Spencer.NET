using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IPropertyInfosGetter
    {
        IEnumerable<PropertyInfo> GetAll(Type type);
    }
}