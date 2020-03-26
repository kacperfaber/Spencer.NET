using System.Reflection;

namespace Odie
{
    public interface IMemberGenerator
    {
        IMember GenerateMember(MemberInfo member);
    }
}