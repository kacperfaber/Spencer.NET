namespace Odie
{
    public class ServiceInitializer : IServiceInitializer
    {
        public IInstanceCreator InstanceCreator;

        public ServiceInitializer(IInstanceCreator instanceCreator)
        {
            InstanceCreator = instanceCreator;
        }

        public void Initialize(Service service, IContainerResolver resolver, IContainerRegistrar registrar)
        {
            object instance = InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, resolver, registrar);
            service.Registration.Instance = instance;
        }
    }
}