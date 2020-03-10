using System;
using System.Linq;

namespace Odie
{
    public class GuidGenerator : IValueGenerator
    {
        public GuidGenerator()
        {
        }

        public object Generate(object parameters, Type parametersType, Type[] exceptedType, out Type valueType)
        {
            if (exceptedType.First() == typeof(string))
            {
                valueType = typeof(string);
                return Guid.NewGuid().ToString();
            }
            
            if (exceptedType.First() == typeof(Guid))
            {
                valueType = typeof(Guid);
                return Guid.NewGuid();
            }
            
            throw new ArgumentException();
        }
    }
}