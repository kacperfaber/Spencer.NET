namespace Odie
{
    public interface IMemberValueSetter
    {
        void SetValue(IMember member, object @object, object value);

        void SetValue(IMember staticMember, object value);
    }
}