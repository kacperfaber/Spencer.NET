using System.Reflection;

namespace Odie
{
    public class MemberValueSetter : IMemberValueSetter
    {
        public void SetValue(MemberInfo member, object @object, object value)
        {
            if (member.MemberType == MemberTypes.Property)
            {
                PropertyInfo prop = (PropertyInfo) member;
                prop.SetValue(@object, value);
            }
            
            else if (member.MemberType == MemberTypes.Field)
            {
                FieldInfo field = (FieldInfo) member;
                field.SetValue(@object, value);
            }
        }
    }
}