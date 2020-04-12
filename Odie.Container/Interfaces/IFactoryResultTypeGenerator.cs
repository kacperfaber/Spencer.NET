using System;

namespace Odie
{
    public interface IFactoryResultTypeGenerator
    {
        Type GenerateResultType(IMember member);
    }
}