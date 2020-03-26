namespace Odie
{
    public interface IInstanceMembersValueInjector
    {
        void InjectAll(IService service, object instance);
    }
}