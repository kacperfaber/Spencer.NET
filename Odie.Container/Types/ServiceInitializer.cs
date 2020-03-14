namespace Odie
{
    public class ServiceInitializer : IServiceInitializer
    {
        public IInstanceCreator InstanceCreator;

        public ServiceInitializer(IInstanceCreator instanceCreator)
        {
            InstanceCreator = instanceCreator;
        }

        public void Initialize(Service service, IContainer container)
        {
            object instance = InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, container);
            service.Registration.Instance = instance;
        }
    }
}