using System;

namespace Odie
{
    public class ReflectionField
    {
        public Type Type { get; set; }

        public MemberType MemberType { get; set; }

        public object Instance { get; set; }
    }
}