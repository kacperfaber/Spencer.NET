using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class ServiceByInterfaceFinder : IServiceByInterfaceFinder
    {
        public IInterfacesExtractor InterfacesExtractor;
        public IGenericTypesComparer Comparer;

        public ServiceByInterfaceFinder(IInterfacesExtractor interfacesExtractor, IGenericTypesComparer comparer)
        {
            InterfacesExtractor = interfacesExtractor;
            Comparer = comparer;
        }

        public IService FindByInterface(IServiceList list, Type @interface)
        {
            foreach (IService service in list.GetServices())
            {
                IEnumerable<IInterface> interfaces = InterfacesExtractor.ExtractInterfaces(service.Registration);

                IEnumerable<IInterface> matchingInterfaces = interfaces
                    .Where(x => x.HasGenericArguments)
                    .Where(x => Comparer.Compare(@interface, x.Type));

                if (matchingInterfaces.Any())
                {
                    return service;
                }
            }

            throw new InvalidOperationException();
        }

        public IEnumerable<IService> FindManyByInterface(IServiceList list, Type @interface)
        {
            foreach (IService service in list.GetServices())
            {
                IEnumerable<IInterface> interfaces = InterfacesExtractor.ExtractInterfaces(service.Registration);

                IEnumerable<IInterface> matchingInterfaces = interfaces
                    .Where(x => x.HasGenericArguments)
                    .Where(x => Comparer.Compare(@interface, x.Type));

                if (matchingInterfaces.Any())
                {
                    yield return service;
                }
            }
        }
    }
}