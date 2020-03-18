using System;

namespace Odie
{
    public class BaseTypeFinder : IBaseTypeFinder
    {
        public Type GetBaseType(Type type)
        {
            return type.BaseType;
        }
    }
}