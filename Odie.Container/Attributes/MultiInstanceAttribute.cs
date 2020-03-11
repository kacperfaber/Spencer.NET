using System;

namespace Odie
{
    public class MultiInstanceAttribute : ServiceFlagAttribute
    {
        public MultiInstanceAttribute() : base(ServiceFlag.MULTI_INSTANCE)
        {
        }
    }
}