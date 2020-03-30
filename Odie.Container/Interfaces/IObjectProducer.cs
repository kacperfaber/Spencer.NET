namespace Odie
{
    public interface IObjectProducer
    {
        object ProduceObject(IService service, IReadOnlyContainer container);
    }
}