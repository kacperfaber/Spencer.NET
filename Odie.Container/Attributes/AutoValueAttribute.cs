using System;

namespace Odie
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AutoValueAttribute : ServiceFlagAttribute
    {
        public AutoValueAttribute() : base(ServiceFlag.AUTO_VALUE)
        {
        }
    }
}