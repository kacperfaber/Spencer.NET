using System;

namespace Spencer.NET
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Method)]
    public class FactoryAttribute : ServiceFlagAttribute
    {
        public Type ResultType { get; set; }
        
        public FactoryAttribute() : base(ServiceFlagConstants.ServiceFactory)
        {
        }

        public FactoryAttribute(Type resultType) : base(ServiceFlagConstants.ServiceFactory)
        {
            ResultType = resultType;
        }
    }
}