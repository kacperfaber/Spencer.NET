using System;

namespace Spencer.NET
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TryInjectAttribute : ServiceFlagAttribute
    {
        public TryInjectAttribute() : base(ServiceFlagConstants.TryInject)
        {
        }
    }
}