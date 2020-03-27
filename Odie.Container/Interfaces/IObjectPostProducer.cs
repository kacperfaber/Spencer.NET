namespace Odie
{
    public interface IObjectPostProducer
    {
        void Produce(object instance, IService service, IContainer container);
    }
}