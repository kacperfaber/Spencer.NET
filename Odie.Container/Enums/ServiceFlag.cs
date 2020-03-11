using System;

namespace Odie
{
    [Flags]
    public enum ServiceFlag
    {
        EMPTY,
        AUTO_VALUE,
        HAS_CONSTRUCTOR,
        HAS_FACTORY,
        MULTI_INSTANCE,
        SINGLE_INSTANCE
    }
}