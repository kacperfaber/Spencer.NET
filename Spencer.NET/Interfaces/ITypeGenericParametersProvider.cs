using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface ITypeGenericParametersProvider
    {
        IEnumerable<Type> ProvideGenericTypes(Type type);
    }
}