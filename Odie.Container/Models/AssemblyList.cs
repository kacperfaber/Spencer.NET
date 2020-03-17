using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class AssemblyList : List<Assembly>
    {
        public void AddAssembly(AssemblyName assembly)
        {
            Add(Assembly.Load(assembly));
        }

        public void AddAssembly(Assembly assembly)
        {
            Add(assembly);
        }

        public void AddAssemblies(params AssemblyName[] names)
        {
            foreach (AssemblyName assemblyName in names)
            {
                Add(Assembly.Load(assemblyName));
            }
        }
    }
}