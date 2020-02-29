using System.Collections.Generic;
using System.Reflection;
using Odie.Commons;

namespace Odie.Engine
{
    public class PropertyInfosFilter : IPropertyInfosFilter
    {
        public List<IFilter<PropertyInfo>> Filters { get; set; }
        
        public IEnumerable<PropertyInfo> Filter(IEnumerable<PropertyInfo> enumerable)
        {
            foreach (IFilter<PropertyInfo> filter in Filters)
            {
                filter.Filter(enumerable);
            }
        }
    }
}