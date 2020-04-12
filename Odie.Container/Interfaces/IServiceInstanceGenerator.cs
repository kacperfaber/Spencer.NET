namespace Odie
{
    public interface IServiceInstanceGenerator
    {
        object GenerateInstance(IService service, IReadOnlyContainer container);
    }
}