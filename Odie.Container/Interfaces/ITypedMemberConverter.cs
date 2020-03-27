namespace Odie
{
    public interface ITypedMemberConverter
    {
        ITypedMember Convert(IMember member);
    }
}