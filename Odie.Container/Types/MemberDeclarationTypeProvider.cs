using System;
using System.Reflection;

namespace Odie
{
    public class MemberDeclarationTypeProvider : IMemberDeclarationTypeProvider
    {
        public Type ProvideDeclarartionType(IMember member)
        {
            return member.Instance switch
            {
                MethodInfo method => method.ReturnType,
                PropertyInfo property => property.PropertyType,
                FieldInfo field => field.FieldType,
                _ => throw new ArgumentException("Gived members can be Fields, Properties and Methods.")
            };
        }
    }
}