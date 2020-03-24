using System;
using System.Reflection;

namespace Odie
{
    public interface IFactoryResultTypeProvider
    {
        Type ProvideResultType(MemberInfo member);
    }
}