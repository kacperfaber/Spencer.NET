using System;

namespace Odie.Engine
{
    public interface IDefaultValueGeneratorsProvider
    {
        IValueGenerator ProvideGenerator(Type exceptedType);
    }
}