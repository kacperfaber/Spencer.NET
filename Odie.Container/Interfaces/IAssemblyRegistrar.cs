using System;
using System.Reflection;

namespace Odie
{
    public interface IAssemblyRegistrar
    {
        void Register(IAssemblyList list, Assembly assembly);

        void RegisterIfNotExist(IAssemblyList list, Type type);

        void RegisterIfNotExist(IAssemblyList list, Assembly assembly);
    }
}