using System.Collections.Generic;
using System.Reflection;
using Odie.Commons;

namespace Odie.Engine
{
    public interface IPropertyInfosFilter
    {
        List<IFilter<PropertyInfo>> Filters { get; set; }
        
        IEnumerable<PropertyInfo> Filter(IEnumerable<PropertyInfo> enumerable);
    }
}