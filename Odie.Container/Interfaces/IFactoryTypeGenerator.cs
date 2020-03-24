using System.Reflection;

namespace Odie
{
    public interface IFactoryTypeGenerator
    {
        int Generate(MemberInfo member);
    }
}