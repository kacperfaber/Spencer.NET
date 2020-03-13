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

        public object Resolve(Service service, IContainerResolver resolver, IContainerRegistrar registrar)
        {
            // TODO
            bool alwaysNew = service.Flags.HasFlag(ServiceFlagConstants.AlwaysNew);

            if (alwaysNew)
            {
                return InstanceCreator.CreateInstance(service.Flags, service.Registration.TargetType, resolver, registrar);
            }

            throw new NotImplementedException();
        }
    }
}