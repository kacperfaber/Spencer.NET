using System;

namespace Spencer.NET
{
    public class BaseTypeFinder : IBaseTypeFinder
    {
        public Type GetBaseType(Type type)
        {
            return type.BaseType;
        }
    }
}