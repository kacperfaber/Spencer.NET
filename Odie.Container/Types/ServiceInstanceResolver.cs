using System;

namespace Odie
{
    public class ServiceInstanceResolver : IServiceInstanceResolver
    {
        public IServiceDataInstanceIsNullChecker InstanceIsNullChecker;
        public IAlwaysNewChecker AlwaysNewChecker;
        public ISingleInstanceChecker SingleInstanceChecker;
        public IServiceRegistrationInstanceSetter InstanceSetter;

        public IServiceInstanceCreator ServiceInstanceCreator;

        public ServiceInstanceResolver(IServiceDataInstanceIsNullChecker instanceIsNullChecker, IAlwaysNewChecker alwaysNewChecker, ISingleInstanceChecker singleInstanceChecker, IServiceRegistrationInstanceSetter instanceSetter, IServiceInstanceCreator serviceInstanceCreator)
        {
            InstanceIsNullChecker = instanceIsNullChecker;
            AlwaysNewChecker = alwaysNewChecker;
            SingleInstanceChecker = singleInstanceChecker;
            InstanceSetter = instanceSetter;
            ServiceInstanceCreator = serviceInstanceCreator;
        }

        public object ResolveInstance(IService service, IContainer container)
        {
            if (AlwaysNewChecker.Check(service))
            {
                return ServiceInstanceCreator.CreateInstance(service, container);
            }

            if  (SingleInstanceChecker.Check(service))
            {
                if (InstanceIsNullChecker.Check(service))
                {
                    object instance = ServiceInstanceCreator.CreateInstance(service, container);
                    InstanceSetter.SetInstance(service.Data, instance);
                }

                return service.Data.Instance;
            }

            throw new Exception("Service have to be SingleInstance or MultiInstance.");
        }
    }
}