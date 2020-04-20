namespace Spencer.NET
{
    public interface IObjectProducer
    {
        object ProduceObject(IService service, IReadOnlyContainer container);
    }
}