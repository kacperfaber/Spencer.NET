using System;

namespace Odie
{
    public class TypeImplementsInterfaceValidator : ITypeImplementsInterfaceValidator
    {
        public bool Validate(Type @class, Type @interface)
        {
            return @interface.IsAssignableFrom(@class);
        }
    }
}