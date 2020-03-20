using System.Linq;
using System.Reflection;

namespace Odie
{
    public class AssemblyListContainsChecker : IAssemblyListContainsChecker
    {
        public bool Contains(IAssemblyList list, Assembly assembly)
        {
            return list.Assemblies.SingleOrDefault(x => x.Equals(assembly)) != null;
        }
    }
}