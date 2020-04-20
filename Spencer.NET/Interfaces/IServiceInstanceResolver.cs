namespace Spencer.NET
{
    public interface IServiceInstanceResolver
    {
        object ResolveInstance(IService service, IReadOnlyContainer container);
    }
}