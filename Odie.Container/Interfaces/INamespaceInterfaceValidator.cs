using System;

namespace Odie
{
    public interface INamespaceInterfaceValidator
    {
        bool Validate(Type @interface);
    }
}