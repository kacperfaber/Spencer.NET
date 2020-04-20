using System;

namespace Spencer.NET
{
    public class TypeIsValueTypeChecker : ITypeIsValueTypeChecker
    {
        public bool Check(Type type)
        {
            return type.IsValueType;
        }
    }
}