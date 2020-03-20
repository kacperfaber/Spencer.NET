using System.Reflection;

namespace Odie
{
    public class AssemblyListAdder : IAssemblyListAdder
    {
        public void Add(IAssemblyList list, Assembly assembly)
        {
            list.AddAssembly(assembly);
        }
    }
}