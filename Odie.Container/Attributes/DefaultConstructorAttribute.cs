using System;

namespace Odie
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class DefaultConstructorAttribute : ServiceFlagAttribute
    {
        public DefaultConstructorAttribute() : base(ServiceFlag.HAS_CONSTRUCTOR)
        {
        }
    }
}