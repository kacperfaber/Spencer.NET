using System.Reflection;

namespace Odie
{
    public interface IAssemblyListContainsChecker
    {
        bool Contains(IAssemblyList list, Assembly assembly);
    }
}