using System;

namespace Odie
{
    public class GenericTypeGenerator : IGenericTypeGenerator
    {
        public Type Generate(Type type, params Type[] arguments)
        {
            return type.MakeGenericType(arguments);
        }
    }
}