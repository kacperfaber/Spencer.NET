namespace Odie
{
    public class ServiceResolverProcessor : IServiceResolverProcessor
    {
        public IServiceHasToInitializeChecker HasToInitializeChecker;
        public IObjectProducer ObjectProducer;
        public IServiceInstanceSetter InstanceSetter;
        
        public void ProcessService(IService service, IContainer container)
        {
            if (HasToInitializeChecker.Check(service))
            {
                object instance = ObjectProducer.ProduceObject(service, container);
                InstanceSetter.SetInstance(service, instance);
            }
        }
    }
}