using System.Reflection;

namespace Odie
{
    public interface IAssemblyListAdder
    {
        void Add(IAssemblyList list, Assembly assembly);
    }
}