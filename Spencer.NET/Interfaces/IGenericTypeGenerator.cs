using System;

namespace Spencer.NET
{
    public interface IGenericTypeGenerator
    {
        Type Generate(Type type, params Type[] arguments);
    }
}