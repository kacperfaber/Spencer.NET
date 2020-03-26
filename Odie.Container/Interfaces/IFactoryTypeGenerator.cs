using System.Reflection;

namespace Odie
{
    public interface IFactoryTypeGenerator
    {
        int Generate(IMember member);
    }
}