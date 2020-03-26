using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IMemberFlagsGenerator
    {
        IEnumerable<int> GenerateFlags(MemberInfo member);
    }
}