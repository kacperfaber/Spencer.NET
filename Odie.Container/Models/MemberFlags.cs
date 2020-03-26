using System.Collections.Generic;

namespace Odie
{
    public class MemberFlags : List<int>, IMemberFlags
    {
        public bool Is(int i)
        {
            return Contains(i);
        }
    }
}