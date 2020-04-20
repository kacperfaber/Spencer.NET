using System;

namespace Spencer.NET
{
    public class TypeContainsGenericParametersChecker : ITypeContainsGenericParametersChecker 
    {
        public bool Check(Type type)
        {
            return type.IsGenericType;
        }
    }
}