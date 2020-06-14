using System;
using System.Reflection;

namespace Spencer.NET
{
    public class FactoryTypeGenerator : IFactoryTypeGenerator
    {
        public int Generate(IMember member)
        {
            if (member.Instance.MemberType == MemberTypes.Method && (member.Instance as MethodInfo).IsPublic)
            {
                return FactoryType.PublicMethod;
            }
            
            return member.Instance.MemberType switch
            {
                MemberTypes.Method => FactoryType.StaticMethod,
                _ => throw new NotImplementedException()
            };
        }
    }
}