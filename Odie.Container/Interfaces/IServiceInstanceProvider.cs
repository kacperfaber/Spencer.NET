namespace Odie
{
    public interface IServiceInstanceProvider
    {
        void ProvideInstance(Service service, IContainerResolver resolver, IContainerRegistrar registrar);
    }
}