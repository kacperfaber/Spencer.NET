using System;

namespace Odie
{
    public interface ITypeImplementsInterfaceValidator
    {
        bool Validate(Type @class, Type @interface);
    }
}