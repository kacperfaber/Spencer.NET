namespace Spencer.NET
{
    public interface ITryInjectMemberValuesInjector
    {
        void InjectAll(IService service, IReadOnlyContainer container, object instance);
    }
}