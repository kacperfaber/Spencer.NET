using System;

namespace Odie
{
    public class ServiceInstanceResolver : IServiceInstanceResolver
    {
        public IRegistrationInstanceIsNullChecker InstanceIsNullChecker;
        public IAlwaysNewChecker AlwaysNewChecker;
        public ISingleInstanceChecker SingleInstanceChecker;
        public IServiceRegistrationInstanceSetter InstanceSetter;

        public IServiceInstanceCreator ServiceInstanceCreator;

        public ServiceInstanceResolver(IRegistrationInstanceIsNullChecker instanceIsNullChecker, IAlwaysNewChecker alwaysNewChecker, ISingleInstanceChecker singleInstanceChecker, IServiceRegistrationInstanceSetter instanceSetter, IServiceInstanceCreator serviceInstanceCreator)
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
                if (InstanceIsNullChecker.Check(service.Registration))
                {
                    object instance = ServiceInstanceCreator.CreateInstance(service, container);
                    InstanceSetter.SetInstance(service.Registration, instance);
                }

                return service.Registration.Instance;
            }

            throw new Exception("Service have to be SingleInstance or MultiInstance.");
        }
    }
}