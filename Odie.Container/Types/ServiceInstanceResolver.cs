using System;

namespace Odie
{
    public class ServiceInstanceResolver : IServiceInstanceResolver
    {
        public IInstanceCreator InstanceCreator;
        public IRegistrationInstanceIsNullChecker InstanceIsNullChecker;
        public IAlwaysNewChecker AlwaysNewChecker;
        public ISingleInstanceChecker SingleInstanceChecker;
        public IServiceRegistrationInstanceSetter InstanceSetter;

        public ServiceInstanceResolver(IInstanceCreator instanceCreator, IRegistrationInstanceIsNullChecker instanceIsNullChecker, IAlwaysNewChecker alwaysNewChecker, ISingleInstanceChecker singleInstanceChecker, IServiceRegistrationInstanceSetter instanceSetter)
        {
            InstanceCreator = instanceCreator;
            InstanceIsNullChecker = instanceIsNullChecker;
            AlwaysNewChecker = alwaysNewChecker;
            SingleInstanceChecker = singleInstanceChecker;
            InstanceSetter = instanceSetter;
        }

        public object ResolveInstance(IService service, IContainer container)
        {
            if (AlwaysNewChecker.Check(service))
            {
                return InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, container);
            }

            if  (SingleInstanceChecker.Check(service))
            {
                bool isNull = InstanceIsNullChecker.Check(service.Registration);
                
                if (isNull)
                {
                    object instance = InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, container);
                    InstanceSetter.SetInstance(service.Registration, instance);
                }

                return service.Registration.Instance;
            }

            throw new Exception("Service have to be SingleInstance or MultiInstance.");
        }
    }
}