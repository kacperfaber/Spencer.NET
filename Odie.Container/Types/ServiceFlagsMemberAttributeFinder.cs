using System;
using System.Reflection;

namespace Odie
{
    public class ServiceFlagsMemberAttributeFinder : IServiceFlagsMemberAttributeFinder
    {
        public bool IsExist(Type type, Type attributeType)
        {
            MemberInfo[] members = type.GetMembers();

            foreach (MemberInfo member in members)
            {
                bool defined = Attribute.IsDefined(member, attributeType);

                if (defined)
                {
                    return true;
                }
            }

            return true;
        }
    }
}