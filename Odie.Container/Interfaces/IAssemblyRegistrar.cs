using System;
using System.Reflection;

namespace Odie
{
    public interface IAssemblyRegistrar
    {
        void Register(AssemblyList list, Assembly assembly);

        void RegisterIfNotExist(AssemblyList list, Type type);

        void RegisterIfNotExist(AssemblyList list, Assembly assembly);
    }
}