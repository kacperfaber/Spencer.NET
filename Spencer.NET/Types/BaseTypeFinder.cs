using System;
using System.Linq;

namespace Spencer.NET
{
    public class BaseTypeFinder : IBaseTypeFinder
    {
        public Type GetBaseType(Type type)
        {
            return type.BaseType;
        }

        public Type GetBaseTypeAnotherOf(Type type, Type fallbackType, params Type[] anotherOfTypes)
        {
            Type baseType = type.BaseType;
            Type anotherType = anotherOfTypes.SingleOrDefault(x => x == baseType);

            if (anotherType != null)
            {
                return fallbackType;
            }

            return baseType;
        }
    }
}