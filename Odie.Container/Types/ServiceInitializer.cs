namespace Odie
{
    public class ServiceInitializer : IServiceInitializer
    {
        public IObjectProducer ObjectProducer;
        public IServiceInstanceSetter InstanceSetter;

        public ServiceInitializer(IObjectProducer objectProducer, IServiceInstanceSetter instanceSetter)
        {
            ObjectProducer = objectProducer;
            InstanceSetter = instanceSetter;
        }

        public void Initialize(IService service, IReadOnlyContainer container)
        {
            object instance = ObjectProducer.ProduceObject(service, container);
            InstanceSetter.SetInstance(service, instance);
        }
    }
}