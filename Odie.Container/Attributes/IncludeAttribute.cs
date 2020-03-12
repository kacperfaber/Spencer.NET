using System;

namespace Odie
{
    public class IncludeAttribute : ServiceFlagAttribute
    {
        public IncludeAttribute(Type type) : base(ServiceFlagConstants.IncludeType, type)
        {
        }
    }
}