namespace Odie
{
    public interface IServiceInstanceProvider
    {
        void ProvideInstance(IService service, IReadOnlyContainer container);
    }
}