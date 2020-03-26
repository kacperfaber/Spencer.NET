using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IAttributesFinder
    {
        IEnumerable<TAttr> FindAttributes<TAttr>(IMember member) where TAttr : class;

        IEnumerable<Attribute> FindAttributes(IMember member, Type attributeInfo);

        IEnumerable<TAttr> FindAttributesEverywhere<TAttr>(Type type, Func<MemberInfo, Attribute, TAttr> func);
        IEnumerable<TAttr> FindAttributesEverywhere<TAttr>(Type type) where TAttr : class;
    }
}