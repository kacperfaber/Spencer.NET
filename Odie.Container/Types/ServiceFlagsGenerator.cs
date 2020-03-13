using System;
using System.Collections.Generic;
using Odie.Commons;

namespace Odie
{
    public class ServiceFlagsGenerator : IServiceFlagsGenerator
    {
        public IAttributesFinder AttributesFinder;
        

        public ServiceFlagsGenerator(IAttributesFinder attributesFinder)
        {
            AttributesFinder = attributesFinder;
        }

        public ServiceFlags GenerateFlags(Type type)
        {
            ServiceFlags flags = ServiceFlags.CreateNew();
            IEnumerable<ServiceFlagAttribute> flagAttributes = AttributesFinder.FindAttributes<ServiceFlagAttribute>(type);

            foreach (ServiceFlagAttribute attribute in flagAttributes)
            {
                flags.Add(attribute.ServiceFlag);
            }

            return flags;
        }
    }
}