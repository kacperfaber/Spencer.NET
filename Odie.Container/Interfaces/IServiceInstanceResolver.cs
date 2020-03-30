namespace Odie
{
    public interface IServiceInstanceResolver
    {
        object ResolveInstance(IService service, IReadOnlyContainer container);
    }
}