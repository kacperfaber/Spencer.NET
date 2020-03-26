using System.Collections.Generic;

namespace Odie
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