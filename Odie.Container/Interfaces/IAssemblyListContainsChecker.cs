using System.Reflection;

namespace Odie
{
    public interface IAssemblyListContainsChecker
    {
        bool Contains(AssemblyList list, Assembly assembly);
    }
}