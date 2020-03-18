using System;

namespace Odie
{
    public class ServiceResolver : IServiceResolver
    {
        public IInstanceCreator InstanceCreator;

        public ServiceResolver(IInstanceCreator instanceCreator)
        {
            InstanceCreator = instanceCreator;
        }

        public object Resolve(IService service, IContainer container)
        {
            // TODO make it beauty
            bool alwaysNew = service.Flags.HasFlag(ServiceFlagConstants.MultiInstance);

            if (alwaysNew)
            {
                return InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, container);
            }

            if  (service.Flags.HasFlag(ServiceFlagConstants.SingleInstance))
            {
                if (service.Registration.Instance == null)
                {
                    service.Registration.Instance = InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, container);
                }

                return service.Registration.Instance;
            }

            throw new NotImplementedException();
        }
    }
}