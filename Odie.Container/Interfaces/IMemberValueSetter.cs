using System.Reflection;

namespace Odie
{
    public interface IMemberValueSetter
    {
        void SetValue(MemberInfo member, object @object, object value);
    }
}