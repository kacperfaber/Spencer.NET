namespace Odie
{
    public interface IServiceInstanceProvider
    {
        void ProvideInstance(Service service, IContainer container);
    }
}