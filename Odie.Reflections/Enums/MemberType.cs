using System;

namespace Odie.Reflections
{
    [Flags]
    public enum MemberType
    {
        UNSIGNED = 0,
        FIELD = 1,
        PROPERTY = 2
    }
}