using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class AssemblyImplementationsFinder : IAssemblyImplementationsFinder
    {
        public IEnumerable<Type> FindImplementations(Assembly assembly, Type @interface)
        {
            return assembly.GetTypes().Where(x => x.GetInterfaces().Contains(@interface));
        }
    }
}