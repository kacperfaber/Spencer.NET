using System;

namespace Odie
{
    public class NamespaceInterfaceValidator : INamespaceInterfaceValidator
    {
        public bool Validate(Type @interface)
        {
            return !@interface.FullName.StartsWith("System");
        }
    }
}