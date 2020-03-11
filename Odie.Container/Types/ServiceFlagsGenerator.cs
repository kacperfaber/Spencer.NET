using System;

namespace Odie
{
    public class ServiceFlagsGenerator : IServiceFlagsGenerator
    {
        public IServiceFlagsAttributeArrayGenerator AttributeArrayGenerator;

        public ServiceFlagsGenerator(IServiceFlagsAttributeArrayGenerator attributeArrayGenerator)
        {
            AttributeArrayGenerator = attributeArrayGenerator;
        }

        public ServiceFlag GenerateFlags(Type type)
        {
            ServiceFlag flag = ServiceFlag.EMPTY;
            ServiceFlagAttribute[] attributes = AttributeArrayGenerator.Generate(type);

            foreach (ServiceFlagAttribute serviceFlagAttribute in attributes)
            {
                flag |= serviceFlagAttribute.ServiceFlag;
            }

            return flag;
        }
    }
}