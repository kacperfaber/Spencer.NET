using System.Reflection;

namespace Spencer.NET
{
    public interface IMemberGenerator
    {
        IMember GenerateMember(MemberInfo member);
    }
}