using System;

namespace Odie
{
    public class ReflectionField
    {
        public Flags Flags { get; set; }
        
        public Type Type { get; set; }

        public MemberType MemberType { get; set; }

        public object Instance { get; set; }
    }
}