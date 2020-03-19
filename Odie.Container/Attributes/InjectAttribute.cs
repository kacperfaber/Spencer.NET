using System;

namespace Odie
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class InjectAttribute : ServiceFlagAttribute
    {
        public InjectAttribute() : base(ServiceFlagConstants.Inject)
        {
        }
    }
}