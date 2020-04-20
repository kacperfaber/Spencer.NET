using System.Reflection;

namespace Spencer.NET
{
    public interface IMember
    {
        MemberInfo Instance { get; set; }

        MemberFlags MemberFlags { get; set; }
    }
}