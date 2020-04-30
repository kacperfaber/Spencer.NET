using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class ImplementationsFinder : IImplementationsFinder
    {
        public List<Type> RegisteredTypes = new List<Type>(); // TODO

        public ITypeImplementsInterfaceValidator Validator;

        public ImplementationsFinder(ITypeImplementsInterfaceValidator validator)
        {
            Validator = validator;
        }

        public IEnumerable<Type> FindImplementations(IAssemblyList assemblies, Type @interface)
        {
            foreach (Assembly assembly in assemblies.GetAssemblies())
            {
                foreach (Type @class in assembly.GetTypes().Where(x => x.IsClass))
                {
                    if (@interface.IsAssignableFrom(@class))
                    {
                        yield return @class;
                    }
                }
            }

            RegisteredTypes = new List<Type>();
        }
    }
}