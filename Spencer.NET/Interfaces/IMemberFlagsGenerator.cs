using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public interface IMemberFlagsGenerator
    {
        IEnumerable<int> GenerateFlags(MemberInfo member);
    }
}