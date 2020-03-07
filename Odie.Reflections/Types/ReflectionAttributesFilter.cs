using System;
using System.Collections.Generic;
using Odie.Commons;

namespace Odie
{
    public class ReflectionAttributesFilter : IReflectionAttributesFilter
    {
        public List<IFilter<Attribute>> Filters { get; set; }

        public ReflectionAttributesFilter()
        {
            Filters = new List<IFilter<Attribute>>();
        }

        public IEnumerable<Attribute> Filter(IEnumerable<Attribute> attributes)
        {
            foreach (IFilter<Attribute> filter in Filters)
            {
                attributes = filter.Filter(attributes);
            }

            return attributes;
        }
    }
}