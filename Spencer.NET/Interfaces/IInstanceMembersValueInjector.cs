namespace Spencer.NET
{
    public interface IInstanceMembersValueInjector
    {
        void InjectAll(IService service, object instance);
    }
}