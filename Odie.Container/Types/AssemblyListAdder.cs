using System.Reflection;

namespace Odie
{
    public class AssemblyListAdder : IAssemblyListAdder
    {
        public void Add(AssemblyList list, Assembly assembly)
        {
            list.AddAssembly(assembly);
        }
    }
}