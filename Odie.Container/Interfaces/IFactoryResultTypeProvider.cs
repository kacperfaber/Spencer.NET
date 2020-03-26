using System;
using System.Reflection;

namespace Odie
{
    public interface IFactoryResultTypeProvider
    {
        Type ProvideResultType(IMember member);
    }
}