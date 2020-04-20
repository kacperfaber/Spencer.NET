using System;

namespace Spencer.NET
{
    public interface IBaseTypeFinder
    {
        Type GetBaseType(Type type);
    }
}