using System;
using System.Collections.Generic;

namespace Odie
{
    public interface ITypeGenericParametersProvider
    {
        IEnumerable<Type> ProvideGenericTypes(Type type);
    }
}