using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class AssemblyListContainsChecker : IAssemblyListContainsChecker
    {
        public bool Contains(IAssemblyList list, Assembly assembly)
        {
            List<Assembly> assemblies = list.GetAssemblies();
            return assemblies.Contains(assembly);
        }
    }
}