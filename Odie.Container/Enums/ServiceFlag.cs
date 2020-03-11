using System;

namespace Odie
{
    [Flags]
    public enum ServiceFlag
    {
        AUTO_VALUE,
        CONSTRCUTOR,
        FACTORY,
        MULTI_INSTANCE,
        SINGLE_INSTANCE
    }
}