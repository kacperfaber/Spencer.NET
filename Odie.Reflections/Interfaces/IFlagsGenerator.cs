using System.Reflection;

namespace Odie
{
    public interface IFlagsGenerator
    {
        Flags GenerateFlags(MemberInfo member);
    }
}