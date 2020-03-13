using System;

namespace Odie
{
    public class Exclude : ServiceFlagAttribute
    {
        public Exclude(Type type) : base(ServiceFlagConstants.IncludeType, type)
        {
        }
    }
}