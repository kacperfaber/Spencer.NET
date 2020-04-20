using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class InterfaceBuilder : Builder<Interface, InterfaceBuilder>, IDisposable
    {
        public InterfaceBuilder(Interface o = default) : base(o)
        {
        }

        public InterfaceBuilder AddType(Type type)
        {
            return Update(x => x.Type = type);
        }

        public InterfaceBuilder HasGenericArguments(bool isGeneric)
        {
            return Update(x => x.HasGenericArguments = isGeneric);
        }

        public InterfaceBuilder AddGenericParameters(IEnumerable<Type> parameters)
        {
            return Update(x => x.GenericParameters = parameters);
        }

        public void Dispose()
        {
        }
    }
}