using System;

namespace Odie
{
    public class TypeIsValueTypeChecker : ITypeIsValueTypeChecker
    {
        public bool Check(Type type)
        {
            return type.IsValueType;
        }
    }
}