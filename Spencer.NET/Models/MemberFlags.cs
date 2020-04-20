using System.Collections.Generic;

namespace Spencer.NET
{
    public class MemberFlags : List<int>, IMemberFlags
    {
        public MemberFlags() : base()
        {
        }

        public bool Is(int i)
        {
            return Contains(i);
        }
    }
}