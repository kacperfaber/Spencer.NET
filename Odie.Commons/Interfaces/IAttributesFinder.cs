using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie.Commons
{
    public interface IAttributesFinder
    {
        IEnumerable<TAttr> FindAttributes<TAttr>(MemberInfo member) where TAttr : class;

        IEnumerable<Attribute> FindAttributes(MemberInfo member, Type attributeInfo);

        IEnumerable<TAttr> FindAttributesEverywhere<TAttr>(Type type, Func<MemberInfo, Attribute, TAttr> func);
    }
}