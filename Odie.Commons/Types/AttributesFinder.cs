using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie.Commons
{
    public class AttributesFinder : IAttributesFinder
    {
        public IEnumerable<TAttr> FindAttributes<TAttr>(MemberInfo member) where TAttr : class
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(member, typeof(TAttr));

            foreach (Attribute attribute in attributes)
            {
                yield return attribute as TAttr;
            }
        }

        public IEnumerable<Attribute> FindAttributes(MemberInfo member, Type attributeInfo)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(member, attributeInfo);

            foreach (Attribute attribute in attributes)
            {
                yield return attribute;
            }
        }

        public IEnumerable<TAttr> FindAttributesEverywhere<TAttr>(Type type, Func<MemberInfo, Attribute, TAttr> func)
        {
            MemberInfo[] members = type.GetMembers();

            foreach (MemberInfo member in members)
            {
                Attribute[] attributes = Attribute.GetCustomAttributes(member, typeof(TAttr));

                foreach (Attribute attribute in attributes)
                {
                    yield return func(member, attribute);
                }
            }
        }
    }
}