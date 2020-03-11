using System;

namespace Odie
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FactoryAttribute : ServiceFlagAttribute
    {
        public FactoryAttribute() : base(ServiceFlag.HAS_FACTORY)
        {
        }
    }
}