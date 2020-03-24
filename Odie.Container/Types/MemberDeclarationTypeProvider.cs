using System;
using System.Reflection;

namespace Odie
{
    public class MemberDeclarationTypeProvider : IMemberDeclarationTypeProvider
    {
        public Type ProvideDeclarartionType(MemberInfo member)
        {
            if (member is MethodInfo method)
            {
                return method.ReturnType;
            }

            else if (member is PropertyInfo property)
            {
                return property.PropertyType;
            }

            else if (member is FieldInfo field)
            {
                return field.FieldType;
            }

            throw new ArgumentException("Gived members can be Fields, Properties and Methods.");
        }
    }
}