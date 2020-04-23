namespace Spencer.NET
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

        public void ProvideInstance(IService service)
        {
            if (AutoValueChecker.Check(service))
            {
                service.Data.Instance = InstanceCreator.CreateInstance(service.Registration.TargetType);
            }

            else if (!AutoValueChecker.Check(service))
            {
                service.Data.Instance = null;
            }
        }
    }
}