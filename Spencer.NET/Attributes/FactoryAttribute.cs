using System;

namespace Spencer.NET
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public class FactoryAttribute : ServiceFlagAttribute
    {
        public FactoryAttribute() : base(ServiceFlagConstants.ServiceFactory)
        {
        }
    }
}