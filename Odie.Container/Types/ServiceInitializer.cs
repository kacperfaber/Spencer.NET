namespace Odie
{
    public class ServiceInitializer : IServiceInitializer
    {
        public IServiceInstanceCreator ServiceInstanceCreator;
        public IServiceRegistrationInstanceSetter InstanceSetter;

        public ServiceInitializer(IServiceInstanceCreator serviceInstanceCreator, IServiceRegistrationInstanceSetter instanceSetter)
        {
            ServiceInstanceCreator = serviceInstanceCreator;
            InstanceSetter = instanceSetter;
        }

        public void Initialize(IService service, IContainer container)
        {
            object instance = ServiceInstanceCreator.CreateInstance(service, container);
            InstanceSetter.SetInstance(service.Data, instance);
        }
    }
}