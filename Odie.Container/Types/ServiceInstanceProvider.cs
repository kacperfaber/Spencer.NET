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

        public void ProvideInstance(IService service, IReadOnlyContainer container)
        {
            if (AutoValueChecker.Check(service))
            {
                service.Data.Instance = InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, container);
            }

            else if (!AutoValueChecker.Check(service))
            {
                service.Data.Instance = null;
            }
        }
    }
}