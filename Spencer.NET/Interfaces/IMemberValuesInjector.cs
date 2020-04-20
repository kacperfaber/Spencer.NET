namespace Spencer.NET
{
    public interface IMemberValuesInjector
    {
        void InjectAll(IService service, IReadOnlyContainer container, object instance);
    }
}