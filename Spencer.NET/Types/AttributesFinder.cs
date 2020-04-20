using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class AttributesFinder : IAttributesFinder
    {
        public IEnumerable<TAttr> FindAttributes<TAttr>(IMember member) where TAttr : class
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(member.Instance, typeof(TAttr));

            foreach (Attribute attribute in attributes)
            {
                yield return attribute as TAttr;
            }
        }

        public IEnumerable<Attribute> FindAttributes(IMember member, Type attributeInfo)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(member.Instance, attributeInfo);

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

            foreach (Attribute attr in Attribute.GetCustomAttributes(type, typeof(TAttr)))
            {
                yield return func(type, attr);
            }
        }

        public IEnumerable<TAttr> FindAttributesEverywhere<TAttr>(Type type) where TAttr : class
        {
            MemberInfo[] members = type.GetMembers();

            foreach (MemberInfo member in members)
            {
                Attribute[] attributes = Attribute.GetCustomAttributes(member, typeof(TAttr));

                foreach (Attribute attribute in attributes)
                {
                    yield return attribute as TAttr;
                }
            }

            foreach (Attribute attr in Attribute.GetCustomAttributes(type, typeof(TAttr)))
            {
                yield return attr as TAttr;
            }
        }
    }
}