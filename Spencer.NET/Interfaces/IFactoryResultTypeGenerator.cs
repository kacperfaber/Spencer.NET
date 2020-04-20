using System;

namespace Spencer.NET
{
    public interface IFactoryResultTypeGenerator
    {
        Type GenerateResultType(IMember member);
    }
}