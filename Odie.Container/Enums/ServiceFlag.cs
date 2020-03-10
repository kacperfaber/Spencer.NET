using System;

namespace Odie
{
    [Flags]
    public enum ServiceFlag
    {
        AUTO_VALUE,
        MULTI_INSTANCE,
        SINGLE_INSTANCE,
        NEVER_REGISTER,
        HAS_DEFAULT_CONSTRUCTOR,
        HAS_DEFAULT_FACTORY
    }
}