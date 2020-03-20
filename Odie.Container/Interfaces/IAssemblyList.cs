using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IAssemblyList
    {
        List<Assembly> Assemblies { get; set; }

        void AddAssembly(Assembly ass);

        void AddAssembly(AssemblyName name);

        void AddAssemblies(params AssemblyName[] assemblies);
    }
}