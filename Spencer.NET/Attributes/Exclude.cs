using System;

namespace Spencer.NET
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class Exclude : ServiceFlagAttribute
    {
        public Exclude(Type type) : base(ServiceFlagConstants.ExcludeType, type)
        {
        }
    }
}