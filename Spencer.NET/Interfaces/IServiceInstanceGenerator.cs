namespace Spencer.NET
{
    public interface IServiceInstanceGenerator
    {
        object GenerateInstance(IService service, IReadOnlyContainer container);
    }
}