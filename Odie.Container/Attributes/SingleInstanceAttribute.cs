using System;

namespace Odie
{
    public class SingleInstanceAttribute : ServiceFlagAttribute
    {
        public SingleInstanceAttribute() : base(ServiceFlag.SINGLE_INSTANCE)
        {
        }
    }
}