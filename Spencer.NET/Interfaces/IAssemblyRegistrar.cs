using System;
using System.Reflection;

namespace Spencer.NET
{
    public interface IAssemblyRegistrar
    {
        void Register(IAssemblyList list, Assembly assembly);

        void RegisterIfNotExist(IAssemblyList list, Type type);

        void RegisterIfNotExist(IAssemblyList list, Assembly assembly);
    }
}