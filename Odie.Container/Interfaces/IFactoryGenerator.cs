using System.Reflection;

namespace Odie
{
    public interface IFactoryGenerator
    {
        IFactory GenerateFactory(MemberInfo member);
    }
}