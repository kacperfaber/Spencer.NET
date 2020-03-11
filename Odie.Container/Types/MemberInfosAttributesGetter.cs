using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class MemberInfosAttributesGetter : IMemberInfosAttributeGetter
    {
        public IEnumerable<TOut> GetAttributes<TOut>(Type type)
        {
            MemberInfo[] members = type.GetMembers();

            foreach (MemberInfo memberInfo in members)
            {
                Type outType = typeof(TOut);
                
                Attribute[] attributes = Attribute.GetCustomAttributes(memberInfo, outType);

                foreach (Attribute attribute in attributes)
                {
                    yield return (TOut) Convert.ChangeType(attribute, outType);
                }
            }
        }

        public IEnumerable<TOut> GetAttributes<TOut>(MemberInfo info)
        {
            Type outType = typeof(TOut);
            Attribute[] attributes = Attribute.GetCustomAttributes(info, outType);

            foreach (Attribute attribute in attributes)
            {
                yield return (TOut) Convert.ChangeType(attribute, outType);
            }
        }
    }
}