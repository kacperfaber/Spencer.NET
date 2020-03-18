using System;
using System.Reflection;

namespace Odie
{
    public class AssemblyRegistrar : IAssemblyRegistrar
    {
        public IAssemblyListContainsChecker ContainsChecker;
        public IAssemblyListAdder AssemblyAdder;

        public AssemblyRegistrar(IAssemblyListAdder assemblyAdder, IAssemblyListContainsChecker containsChecker)
        {
            AssemblyAdder = assemblyAdder;
            ContainsChecker = containsChecker;
        }

        public void Register(AssemblyList list, Assembly assembly)
        {
            AssemblyAdder.Add(list, assembly);
        }

        public void RegisterIfNotExist(AssemblyList list, Type type)
        {
            Assembly ass = type.Assembly;
            
            if (!ContainsChecker.Contains(list, ass))
            {
                AssemblyAdder.Add(list, ass);
            }
        }

        public void RegisterIfNotExist(AssemblyList list, Assembly assembly)
        {
            if (!ContainsChecker.Contains(list, assembly))
            {
                AssemblyAdder.Add(list, assembly);
            }
        }
    }
}