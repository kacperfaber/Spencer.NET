using System;

namespace Odie
{
    public interface IDefaultValueGeneratorsProvider
    {
        IValueGenerator ProvideGenerator(Type exceptedType);
    }
}