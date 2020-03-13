using System;
using System.Reflection;

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