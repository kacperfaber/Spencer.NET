using System;

namespace Odie
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