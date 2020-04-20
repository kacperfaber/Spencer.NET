using System;

namespace Spencer.NET
{
    public class TypedMember : ITypedMember
    {
        public Type Type { get; set; }
        
        public TypedMember(Type type)
        {
            Type = type;
        }
    }
}