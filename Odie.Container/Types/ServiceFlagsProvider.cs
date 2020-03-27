using System;
using System.Collections.Generic;

namespace Odie
{
    public class ServiceFlagsProvider : IServiceFlagsProvider
    {
        public IAttributesFinder AttributesFinder;
        public IMemberGenerator MemberGenerator;

        public ServiceFlagsProvider(IAttributesFinder attributesFinder, IMemberGenerator memberGenerator)
        {
            AttributesFinder = attributesFinder;
            MemberGenerator = memberGenerator;
        }

        public ServiceFlags ProvideFlags(Type type)
        {
            ServiceFlags flags = ServiceFlags.CreateNew();
            IEnumerable<ServiceFlagAttribute> flagAttributes = AttributesFinder.FindAttributesEverywhere(type, (member, attr) =>
            {
                ServiceFlagAttribute flagAttr = (ServiceFlagAttribute) attr;
                ServiceFlag sflag = flagAttr.ServiceFlag;

                return new ServiceFlagAttribute() {ServiceFlag = new ServiceFlag(sflag.Name, sflag.Value)
                {
                    Member = MemberGenerator.GenerateMember(member)
                }};
            });

            foreach (ServiceFlagAttribute attribute in flagAttributes)
            {
                flags.AddFlag(attribute.ServiceFlag.Name, attribute.ServiceFlag.Value, attribute.ServiceFlag.Member);
            }

            return flags;
        }
    }
}