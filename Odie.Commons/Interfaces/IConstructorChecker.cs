using System.Reflection;

namespace Odie.Commons
{
    public interface IConstructorChecker
    {
        bool Check(MemberInfo member);
    }
}