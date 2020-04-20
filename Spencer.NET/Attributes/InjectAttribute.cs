using System;

namespace Spencer.NET
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class InjectAttribute : ServiceFlagAttribute
    {
        public InjectAttribute() : base(ServiceFlagConstants.Inject)
        {
        }
    }
}