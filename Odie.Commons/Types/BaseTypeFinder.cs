using System;

namespace Odie.Commons
{
    public class BaseTypeFinder : IBaseTypeFinder
    {
        public Type GetBaseType(Type type)
        {
            return type.BaseType;
        }
    }
}