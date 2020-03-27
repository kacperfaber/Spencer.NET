namespace Odie
{
    public interface IObjectProducer
    {
        object ProduceObject(IService service, IContainer container);
    }
}