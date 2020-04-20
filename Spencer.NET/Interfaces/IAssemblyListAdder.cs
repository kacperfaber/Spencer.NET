using System.Reflection;

namespace Spencer.NET
{
    public interface IAssemblyListAdder
    {
        void Add(IAssemblyList list, Assembly assembly);
    }
}