using System;
using System.Reflection;

namespace Odie
{
    public interface IFactoryResultResultTypeProvider
    {
        Type ProvideResultType(MemberInfo member);
    }
}