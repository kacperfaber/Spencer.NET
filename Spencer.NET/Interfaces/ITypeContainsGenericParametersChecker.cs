using System;

namespace Spencer.NET
{
    public interface ITypeContainsGenericParametersChecker
    {
        bool Check(Type type);
    }
}