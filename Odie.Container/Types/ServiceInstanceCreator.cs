namespace Odie
{
    public class ServiceInstanceCreator : IServiceInstanceCreator
    {
        public IServiceHasRegisterParametersChecker HasRegisterParametersChecker;
        public IInstanceCreator InstanceCreator;

        public ServiceInstanceCreator(IInstanceCreator instanceCreator, IServiceHasRegisterParametersChecker hasRegisterParametersChecker)
        {
            InstanceCreator = instanceCreator;
            HasRegisterParametersChecker = hasRegisterParametersChecker;
        }

        public object CreateInstance(IService service, IContainer container)
        {
            if (HasRegisterParametersChecker.Check(service))
            {
                return InstanceCreator.CreateInstance(service.Registration.TargetType, service.Registration.RegisterParameter);
            }

            else
            {
                return InstanceCreator.CreateInstance(service.Registration.TargetType, container);
            }
        }
    }
}