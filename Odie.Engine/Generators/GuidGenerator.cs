using System;

namespace Odie.Engine
{
    public class GuidGenerator : IValueGenerator
    {
        public object Generate(object parameters, Type parametersType, Type exceptedType, ref Type valueType)
        {
            if (exceptedType == typeof(Guid))
            {
                valueType = typeof(Guid);
                return Guid.NewGuid();
            }

            else if (exceptedType == typeof(string))
            {
                valueType = typeof(string);
                return Guid.NewGuid().ToString();
            }
            
            throw new ArgumentException($"{GetType().Name} supports output type: {typeof(Guid)}, {typeof(string)}");
        }
    }
}