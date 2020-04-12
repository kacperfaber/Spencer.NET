using System;

namespace Odie
{
    public interface IFactoryResultTypeProvider
    {
        Type ProvideResultType(IMember member);
    }
}