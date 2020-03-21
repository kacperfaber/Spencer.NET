namespace Odie
{
    public class ServiceInstanceCreator : IServiceInstanceCreator
    {
        public IServiceHasConstructorParametersChecker HasConstructorParametersChecker;
        public IInstanceCreator InstanceCreator;

        public ServiceInstanceCreator(IInstanceCreator instanceCreator, IServiceHasConstructorParametersChecker hasConstructorParametersChecker)
        {
            InstanceCreator = instanceCreator;
            HasConstructorParametersChecker = hasConstructorParametersChecker;
        }

        public object CreateInstance(IService service, IContainer container)
        {
            if (HasConstructorParametersChecker.Check(service))
            {
                return InstanceCreator.CreateInstance(service.Registration.TargetType, service.Registration.ConstructorParameter);
            }

            else
            {
                return InstanceCreator.CreateInstance(service.Registration.TargetType, container);
            }
        }
    }
}