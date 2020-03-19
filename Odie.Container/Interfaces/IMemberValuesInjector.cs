namespace Odie
{
    public interface IMemberValuesInjector
    {
        void InjectAll(IService service, IContainer container, object instance);
    }
}