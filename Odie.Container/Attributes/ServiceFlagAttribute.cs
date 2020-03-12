using System;
using System.Reflection;

namespace Odie
{
    public class ServiceFlagAttribute : Attribute
    {
        public ServiceFlag ServiceFlag;

        public ServiceFlagAttribute(string name, object value = null, MemberInfo parentMember = null)
        {
            ServiceFlag = new ServiceFlag(name, value) {Parent = parentMember};
        }
    }
}