using System;
using System.Reflection;

namespace Spencer.NET
{
    public class FactoryTypeGenerator : IFactoryTypeGenerator
    {
        public int Generate(IMember member)
        {
            MethodInfo method = (member.Instance as MethodInfo);
            
            if (member.Instance.MemberType == MemberTypes.Method &&
                (method.IsPublic && method.IsStatic == false))
            {
                return FactoryType.PublicMethod;
            }

            else return FactoryType.StaticMethod;
        }
    }
}