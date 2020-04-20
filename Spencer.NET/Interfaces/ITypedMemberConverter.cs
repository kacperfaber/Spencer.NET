namespace Spencer.NET
{
    public interface ITypedMemberConverter
    {
        ITypedMember Convert(IMember member);
    }
}