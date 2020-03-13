namespace Odie
{
    public interface IServiceInitializer
    {
        void Initialize(Service service, IContainerResolver resolver, IContainerRegistrar registrar);
    }
}