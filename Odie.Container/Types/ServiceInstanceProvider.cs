namespace Odie
{
    public class ServiceInstanceProvider : IServiceInstanceProvider
    {
        public IServiceIsAutoValueChecker AutoValueChecker;
        public IInstanceCreator InstanceCreator;

        public ServiceInstanceProvider(IInstanceCreator instanceCreator, IServiceIsAutoValueChecker autoValueChecker)
        {
            InstanceCreator = instanceCreator;
            AutoValueChecker = autoValueChecker;
        }

        public void ProvideInstance(Service service, IContainer container)
        {
            if (AutoValueChecker.Check(service))
            {
                service.Registration.Instance = InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, container);
            }

            else if (!AutoValueChecker.Check(service))
            {
                service.Registration.Instance = null;
            }
        }
    }
}