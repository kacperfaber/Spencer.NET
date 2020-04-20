using System;

namespace Spencer.NET
{
    public interface IFactoryResultTypeProvider
    {
        Type ProvideResultType(IMember member);
    }
}