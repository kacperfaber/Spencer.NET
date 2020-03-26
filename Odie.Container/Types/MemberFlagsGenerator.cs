using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class MemberFlagsGenerator : IMemberFlagsGenerator
    {
        public IEnumerable<int> GenerateFlags(MemberInfo member)
        {
            if (member is ConstructorInfo ctor)
            {
                yield return MemberFlag.Constructor;

                yield return ctor.GetParameters().Length > 0 ? MemberFlag.Parametrized : MemberFlag.NotParametrized;
                yield return ctor.IsStatic ? MemberFlag.Static : 0;
                yield return ctor.IsPublic ? MemberFlag.Public : 0;
                yield return ctor.IsPrivate ? MemberFlag.Private : 0;
            }

            if (member is PropertyInfo property)
            {
                yield return MemberFlag.Property;

                MethodInfo accessor = property.GetAccessors(true)[0];
                yield return accessor.IsStatic ? MemberFlag.Static : 0;
                yield return accessor.IsPublic ? MemberFlag.Public : 0;
                yield return accessor.IsPrivate ? MemberFlag.Private : 0;
            }
                

            if (member is FieldInfo field)
            {
                yield return MemberFlag.Field;
                
                yield return field.IsStatic ? MemberFlag.Static : 0;
                yield return field.IsPublic ? MemberFlag.Public : 0;
                yield return field.IsPrivate ? MemberFlag.Private : 0;
            }
                
            if (member is MethodInfo method)
            {
                yield return MemberFlag.Method;

                yield return method.IsGenericMethod ? MemberFlag.GenericParametrized : MemberFlag.NotGenericParametrized;
                yield return method.ReturnType == typeof(void) ? MemberFlag.ReturnsVoid : MemberFlag.ReturnsValue;
                yield return method.GetParameters().Length > 0 ? MemberFlag.Parametrized : MemberFlag.NotParametrized;
                yield return method.IsStatic ? MemberFlag.Static : 0;
                yield return method.IsPublic ? MemberFlag.Public : 0;
                yield return method.IsPrivate ? MemberFlag.Private : 0;
            }
        }
    }
}