using System.Reflection;

namespace Spencer.NET
{
    public interface IAssemblyListContainsChecker
    {
        bool Contains(IAssemblyList list, Assembly assembly);
    }
}