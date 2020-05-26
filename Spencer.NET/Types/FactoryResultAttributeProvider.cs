using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class FactoryResultAttributeProvider : IFactoryResultAttributeProvider
    {
        public Attribute ProvideAttributeOrNull(IEnumerable<Attribute> attributes)
        {
            Attribute factoryResultAttribute = attributes.SingleOrDefault(x => x is FactoryResult);

            if (factoryResultAttribute == null)
            {
                return attributes.Where(x => (x as FactoryAttribute)?.ResultType != null).FirstOrDefault();
            }

            return factoryResultAttribute;
        }
    }
}