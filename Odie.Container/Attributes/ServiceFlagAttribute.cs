using System;

namespace Odie
{
    public class ServiceFlagAttribute : Attribute, IConvertible
    {
        public ServiceFlag ServiceFlag { get; set; }

        public ServiceFlagAttribute(ServiceFlag serviceFlag = ServiceFlag.EMPTY)
        {
            ServiceFlag = serviceFlag;
        }
    }
}