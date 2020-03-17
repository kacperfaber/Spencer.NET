using System.Linq;
using System.Reflection;

namespace Odie
{
    public class AssemblyListContainsChecker : IAssemblyListContainsChecker
    {
        public bool Contains(AssemblyList list, Assembly assembly)
        {
            return list.SingleOrDefault(x => x.Equals(assembly)) != null;
        }
    }
}