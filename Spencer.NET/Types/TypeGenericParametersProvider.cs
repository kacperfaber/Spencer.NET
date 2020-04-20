using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class TypeGenericParametersProvider : ITypeGenericParametersProvider
    {
        public IEnumerable<Type> ProvideGenericTypes(Type type)
        {
            return type.GetGenericArguments().AsEnumerable();
        }
    }
}