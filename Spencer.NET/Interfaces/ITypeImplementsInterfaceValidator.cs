using System;

namespace Spencer.NET
{
    public interface ITypeImplementsInterfaceValidator
    {
        bool Validate(Type @class, Type @interface);
    }
}