using System.Reflection;

namespace Odie
{
    public class Member : IMember
    {
        public Member()
        {
            MemberFlags = new MemberFlags();
        }
        
        public MemberInfo Instance { get; set; }
        public MemberFlags MemberFlags { get; set; }
    }
}