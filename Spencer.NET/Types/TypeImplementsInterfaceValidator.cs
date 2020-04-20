using System;

namespace Spencer.NET
{
    public class TypeImplementsInterfaceValidator : ITypeImplementsInterfaceValidator
    {
        public bool Validate(Type @class, Type @interface)
        {
            return @interface.IsAssignableFrom(@class);
        }
    }
}