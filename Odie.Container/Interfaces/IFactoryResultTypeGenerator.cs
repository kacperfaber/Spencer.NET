using System;
using System.Reflection;

namespace Odie
{
    public interface IFactoryResultTypeGenerator
    {
        Type GenerateResultType(MemberInfo member);
    }
}