using System;

namespace Spencer.NET
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class AutoAttribute : ServiceFlagAttribute
    {
        public AutoAttribute() : base(ServiceFlagConstants.Auto)
        {
        }
    }
}