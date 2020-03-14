using System;
using System.Collections.Generic;
using Odie.Commons;

namespace Odie
{
    public class ServiceFlagsProvider : IServiceFlagsProvider
    {
        public IAttributesFinder AttributesFinder;

        public ServiceFlagsProvider(IAttributesFinder attributesFinder)
        {
            AttributesFinder = attributesFinder;
        }

        public ServiceFlags ProvideFlags(Type type)
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