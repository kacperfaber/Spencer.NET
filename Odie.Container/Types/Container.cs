using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class Container : IContainer
    {
        private List<Service> Services = new List<Service>();

        public IServiceResolver ServiceResolver;
        public IServiceRegistrar ServiceRegistrar;
        public IServiceGenerator ServiceGenerator;
        public IServiceFinder ServiceFinder;
        public IServiceInitializer ServiceInitializer;
        public IServiceIsAutoValueChecker ServiceIsAutoValueChecker;
        
        public object Resolve(Type key)
        {
            Service service = ServiceFinder.Find(Services, key);
            object result = ServiceResolver.Resolve(service, this, this);

            return result;
        }

        public bool Has(Type key)
        {
            throw new NotImplementedException();
        }

        public void Register(Type type)
        {
            Service service = ServiceGenerator.GenerateService(type);

            if (ServiceIsAutoValueChecker.Check(service))
            {
                ServiceInitializer.Initialize(service, this, this);
            }
            
            ServiceRegistrar.Register(Services, service);
        }
    }
}