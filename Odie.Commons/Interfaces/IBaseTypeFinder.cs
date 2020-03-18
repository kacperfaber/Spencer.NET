using System;

namespace Odie
{
    public interface IBaseTypeFinder
    {
        Type GetBaseType(Type type);
    }
}