using System;

namespace Odie
{
    public class TypeIsArrayChecker : ITypeIsArrayChecker
    {
        public bool Check(Type type)
        {
            return type.IsArray;
        }
    }
}