using System;

namespace Odie
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class ServiceConstructorAttribute : ServiceFlagAttribute
    {
        public ServiceConstructorAttribute() : base(ServiceFlagConstants.ServiceCtor)
        {
        }
    }
}