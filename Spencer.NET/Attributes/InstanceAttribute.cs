using System;

namespace Spencer.NET
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class InstanceAttribute : ServiceFlagAttribute
    {
        public InstanceAttribute() : base(ServiceFlagConstants.Instance)
        {
        }
    }
}