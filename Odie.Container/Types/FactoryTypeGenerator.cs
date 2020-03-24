using System;
using System.Reflection;

namespace Odie
{
    public class FactoryTypeGenerator : IFactoryTypeGenerator
    {
        public int Generate(MemberInfo member)
        {
            return member.MemberType switch
            {
                MemberTypes.Field => FactoryType.StaticField,
                MemberTypes.Property => FactoryType.StaticProperty,
                MemberTypes.Method => FactoryType.StaticMethod,
                _ => throw new NotImplementedException()
            };
        }
    }
}