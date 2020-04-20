using System.Reflection;

namespace Spencer.NET
{
    public class MemberValueSetter : IMemberValueSetter
    {
        public void SetValue(IMember member, object @object, object value)
        {
            if (member.Instance.MemberType == MemberTypes.Property)
            {
                PropertyInfo prop = (PropertyInfo) member.Instance;
                prop.SetValue(@object, value);
            }
            
            else if (member.Instance.MemberType == MemberTypes.Field)
            {
                FieldInfo field = (FieldInfo) member.Instance;
                field.SetValue(@object, value);
            }
        }

        public void SetValue(IMember staticMember, object value)
        {
            if (staticMember.Instance.MemberType == MemberTypes.Property)
            {
                PropertyInfo prop = (PropertyInfo) staticMember.Instance;
                prop.SetValue(null, value);
            }
            
            else if (staticMember.Instance.MemberType == MemberTypes.Field)
            {
                FieldInfo field = (FieldInfo) staticMember.Instance;
                field.SetValue(null, value);
            }
        }
    }
}