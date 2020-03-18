using System.Reflection;

namespace Odie
{
    public interface IAssemblyListAdder
    {
        void Add(AssemblyList list, Assembly assembly);
    }
}