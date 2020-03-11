using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IMemberInfosAttributeGetter
    {
        IEnumerable<TOut> GetAttributes<TOut>(Type type);

        IEnumerable<TOut> GetAttributes<TOut>(MemberInfo info);
    }
}