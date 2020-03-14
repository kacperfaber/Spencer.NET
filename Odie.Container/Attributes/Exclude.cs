using System;

namespace Odie
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class Exclude : ServiceFlagAttribute
    {
        public Exclude(Type type) : base(ServiceFlagConstants.ExcludeType, type)
        {
        }
    }
}