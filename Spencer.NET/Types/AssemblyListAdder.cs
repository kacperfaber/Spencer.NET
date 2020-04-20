using System.Reflection;

namespace Spencer.NET
{
    public class AssemblyListAdder : IAssemblyListAdder
    {
        public void Add(IAssemblyList list, Assembly assembly)
        {
            list.AddAssembly(assembly);
        }
    }
}