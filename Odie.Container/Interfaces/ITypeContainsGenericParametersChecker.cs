using System;

namespace Odie
{
    public interface ITypeContainsGenericParametersChecker
    {
        bool Check(Type type);
    }
}