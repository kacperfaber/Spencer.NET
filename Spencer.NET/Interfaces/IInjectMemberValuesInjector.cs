namespace Spencer.NET
{
    public interface IInjectMemberValuesInjector
    {
        void InjectAll(IService service, IReadOnlyContainer container, object instance);
    }
}