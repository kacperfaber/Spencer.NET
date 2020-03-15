using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class TypeGenericParametersProvider : ITypeGenericParametersProvider
    {
        public IEnumerable<Type> ProvideGenericTypes(Type type)
        {
            return type.GetGenericArguments().AsEnumerable();
        }
    }
}