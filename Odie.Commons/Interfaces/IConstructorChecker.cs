using System.Reflection;

namespace Odie
{
    public interface IConstructorChecker
    {
        bool Check(MemberInfo member);
    }
}