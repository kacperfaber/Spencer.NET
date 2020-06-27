using System;

namespace Spencer.NET
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoValueAttribute : ServiceFlagAttribute
    {
        public AutoValueAttribute() : base(ServiceFlagConstants.AutoValue, null)
        {
        }
    }
}