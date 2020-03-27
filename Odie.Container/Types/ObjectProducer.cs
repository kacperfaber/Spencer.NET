namespace Odie
{
    public class ObjectProducer : IObjectProducer
    {
        public IInstanceGenerator InstanceGenerator;
        public IObjectPostProducer PostProducer;
        
        public object ProduceObject(IService service, IContainer container)
        {
            object instance = InstanceGenerator.GenerateInstance(service.Registration.TargetType, service.Flags);

            PostProducer.Produce(instance, service, container);
            return instance;
        }
    }
}