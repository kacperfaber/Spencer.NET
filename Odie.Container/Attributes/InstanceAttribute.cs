using System;

namespace Odie
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class InstanceAttribute : ServiceFlagAttribute
    {
        public InstanceAttribute() : base(ServiceFlagConstants.Instance)
        {
        }
    }
}