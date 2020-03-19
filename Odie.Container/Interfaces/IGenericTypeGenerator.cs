using System;

namespace Odie
{
    public interface IGenericTypeGenerator
    {
        Type Generate(Type type, params Type[] arguments);
    }
}