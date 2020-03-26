using System.Reflection;

namespace Odie
{
    public interface IMember
    {
        MemberInfo Instance { get; set; }
    }
}