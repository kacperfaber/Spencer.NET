using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceFlagsProvider : IServiceFlagsProvider
    {
        public IAttributesFinder AttributesFinder;
        
        // introduce members of type to array.
        // then we'll be have better optimalization TODO
        // and clean

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

                return new ServiceFlagAttribute() {ServiceFlag = new ServiceFlag(sflag.Name, sflag.Value)
                {
                    Parent = member
                }};
            });

            foreach (ServiceFlagAttribute attribute in flagAttributes)
            {
                flags.AddFlag(attribute.ServiceFlag.Name, attribute.ServiceFlag.Value, attribute.ServiceFlag.Parent);
            }

            return flags;
        }
    }
}