namespace Spencer.NET
{
    public interface IServiceInitializer
    {
        void Initialize(IService service, IReadOnlyContainer container);
    }
}