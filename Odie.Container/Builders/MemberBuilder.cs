using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class MemberBuilder : Builder<Member, MemberBuilder>, IDisposable
    {
        public MemberBuilder(Member model = null) : base(model)
        {
        }

        public MemberBuilder AddMemberInfo(MemberInfo memberInfo)
        {
            return Update(x => x.Instance = memberInfo);
        }

        public MemberBuilder AddFlag(int flag)
        {
            return Update(x => x.MemberFlags.Add(flag));
        }
        
        public MemberBuilder AddFlags(IEnumerable<int> flags)
        {
            List<int> list = flags.ToList();
            return Update(x => x.MemberFlags.AddRange(flags));
        }

        public void Dispose()
        {
        }

        
    }
}