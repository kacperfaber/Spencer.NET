namespace Odie
{
    public class ServiceInitializer : IServiceInitializer
    {
        public IInstanceCreator InstanceCreator;
        public IServiceRegistrationInstanceSetter InstanceSetter;

        public ServiceInitializer(IInstanceCreator instanceCreator, IServiceRegistrationInstanceSetter instanceSetter)
        {
            InstanceCreator = instanceCreator;
            InstanceSetter = instanceSetter;
        }

        public void Initialize(Service service, IContainer container)
        {
            object instance = InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, container);
            InstanceSetter.SetInstance(service.Registration, instance);
        }
    }
}