using System;

namespace Spencer.NET
{
    public class NamespaceInterfaceValidator : INamespaceInterfaceValidator
    {
        public bool Validate(Type @interface)
        {
            return !@interface.FullName.StartsWith("System");
        }
    }
}