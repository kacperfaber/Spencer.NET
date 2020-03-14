namespace Odie
{
    public interface IServiceInitializer
    {
        void Initialize(Service service, IContainer container);
    }
}