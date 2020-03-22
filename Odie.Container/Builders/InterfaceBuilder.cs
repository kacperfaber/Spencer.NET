using System;
using System.Collections.Generic;

namespace Odie
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

        public InterfaceBuilder IsGeneric(bool isGeneric)
        {
            return Update(x => x.IsGeneric = isGeneric);
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