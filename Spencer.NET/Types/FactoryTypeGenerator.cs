using System;
using System.Reflection;

namespace Spencer.NET
{
    public class FactoryTypeGenerator : IFactoryTypeGenerator
    {
        public int Generate(IMember member)
        {
            return member.Instance.MemberType switch
            {
                MemberTypes.Field => FactoryType.StaticField,
                MemberTypes.Property => FactoryType.StaticProperty,
                MemberTypes.Method => FactoryType.StaticMethod,
                _ => throw new NotImplementedException()
            };
        }
    }
}