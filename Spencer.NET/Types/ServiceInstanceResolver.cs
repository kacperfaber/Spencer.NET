using System;
using Spencer.NET.Extensions;

namespace Spencer.NET
{
    public class ServiceInstanceResolver : IServiceInstanceResolver
    {
        public IServiceInstanceSetter InstanceSetter;
        public IObjectProducer ObjectProducer;
        public IServiceHasToInitializeChecker HasToInitializeChecker;

        public ServiceInstanceResolver(IServiceInstanceSetter instanceSetter, IObjectProducer objectProducer, IServiceHasToInitializeChecker hasToInitializeChecker)
        {
            InstanceSetter = instanceSetter;
            ObjectProducer = objectProducer;
            HasToInitializeChecker = hasToInitializeChecker;
        }

        public object ResolveInstance(IService service, IReadOnlyContainer container)
        {   
            if (HasToInitializeChecker.Check(service))
            {
                object instance = ObjectProducer.ProduceObject(service, container);
                InstanceSetter.SetInstance(service, instance);

                return instance;
            }

            else
            {
                if (service.Registration.RegistrationFlags.Has(RegistrationFlagConstants.IsMultiInstance))
                {
                    return ObjectProducer.ProduceObject(service, container);
                }
                
                else if (service.Registration.RegistrationFlags.Has(RegistrationFlagConstants.IsSingleInstance))
                {
                    return service.Data.Instance;
                }

                throw new Exception();
            }
        }
    }
}