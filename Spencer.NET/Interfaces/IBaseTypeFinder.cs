using System;

namespace Spencer.NET
{
    public interface IBaseTypeFinder
    {
        Type GetBaseType(Type type);
        Type GetBaseTypeAnotherOf(Type type, Type fallbackType, params Type[] anotherOfTypes);
    }
}