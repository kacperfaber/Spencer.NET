using System;
using System.Collections.Generic;

namespace Odie
{
    public class RegistrationInterfacesFilter : IRegistrationInterfacesFilter
    {
        public INamespaceInterfaceValidator NamespaceValidator;

        public RegistrationInterfacesFilter(INamespaceInterfaceValidator namespaceValidator)
        {
            NamespaceValidator = namespaceValidator;
        }

        public IEnumerable<Type> Filter(Type[] interfaces)
        {
            foreach (Type i in interfaces)
            {
                if (NamespaceValidator.Validate(i))
                    yield return i;
            }
        }
    }
}