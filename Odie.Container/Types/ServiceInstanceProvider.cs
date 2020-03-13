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

        public void ProvideInstance(Service service, IContainerResolver resolver, IContainerRegistrar registrar)
        {
            if (AutoValueChecker.Check(service))
            {
                service.Registration.Instance = InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, resolver, registrar);
            }

            else if (!AutoValueChecker.Check(service))
            {
                service.Registration.Instance = null;
            }
        }
    }
}