using System;

namespace Odie
{
    public class ServiceFlagAttribute : Attribute
    {
        public ServiceFlag ServiceFlag;

        public ServiceFlagAttribute(string name, object value = null)
        {
            ServiceFlag = new ServiceFlag(name, value);
        }

        public ServiceFlagAttribute()
        {
        }
    }
}