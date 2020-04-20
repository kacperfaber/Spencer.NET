using System;

namespace Spencer.NET
{
    public class TypeIsArrayChecker : ITypeIsArrayChecker
    {
        public bool Check(Type type)
        {
            return type.IsArray;
        }
    }
}