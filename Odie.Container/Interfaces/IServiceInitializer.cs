namespace Odie
{
    public interface IServiceInitializer
    {
        void Initialize(IService service, IContainer container);
    }
}