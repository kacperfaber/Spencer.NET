using System;

namespace Odie.Commons
{
    public interface IBaseTypeFinder
    {
        Type GetBaseType(Type type);
    }
}