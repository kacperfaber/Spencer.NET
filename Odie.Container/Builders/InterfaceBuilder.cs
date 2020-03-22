using System;

namespace Odie
{
    public class InterfaceBuilder : Builder<Interface, InterfaceBuilder>
    {
        public InterfaceBuilder AddType(Type type)
        {
            return Update(x => x.Type = type);
        }

        public InterfaceBuilder IsGeneric(bool isGeneric)
        {
            return Update(x => x.IsGeneric = isGeneric);
        }

        public InterfaceBuilder AddGenericParameters(Type[] parameters)
        {
            return Update(x => x.GenericParameters = parameters);
        }
    }
}