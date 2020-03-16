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
            IEnumerable<ServiceFlagAttribute> flagAttributes = AttributesFinder.FindAttributesEverywhere<ServiceFlagAttribute>(type, (member, attr) =>
            {
                ServiceFlagAttribute flagAttr = (ServiceFlagAttribute) attr;
                ServiceFlag sflag = flagAttr.ServiceFlag;

                return new ServiceFlagAttribute(sflag.Name, sflag.Value, member);
            });

            foreach (ServiceFlagAttribute attribute in flagAttributes)
            {
                flags.AddFlag(attribute.ServiceFlag.Name, attribute.ServiceFlag.Value, attribute.ServiceFlag.Parent);
            }

            return flags;
        }
    }
}