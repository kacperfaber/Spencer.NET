using System;
using System.Reflection;

namespace Odie
{
    public interface IFactoryResultTypeGenerator
    {
        Type GenerateResultType(IMember member);
    }
}