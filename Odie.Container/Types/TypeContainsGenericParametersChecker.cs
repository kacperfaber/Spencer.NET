using System;

namespace Odie
{
    public class TypeContainsGenericParametersChecker : ITypeContainsGenericParametersChecker 
    {
        public bool Check(Type type)
        {
            return type.IsGenericType;
        }
    }
}