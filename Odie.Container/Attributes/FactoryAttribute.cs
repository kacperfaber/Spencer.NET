using System;

namespace Odie
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public class FactoryAttribute : ServiceFlagAttribute
    {
        public FactoryAttribute() : base(ServiceFlagConstants.ServiceFactory)
        {
        }
    }
}