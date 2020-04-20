using System;

namespace Spencer.NET
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class ServiceConstructorAttribute : ServiceFlagAttribute
    {
        public ServiceConstructorAttribute() : base(ServiceFlagConstants.ServiceCtor)
        {
        }
    }
}