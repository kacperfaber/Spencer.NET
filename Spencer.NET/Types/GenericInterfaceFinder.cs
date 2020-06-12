using System;
using System.Collections.Generic;
using System.Linq;
using Spencer.NET.Extensions;

namespace Spencer.NET
{
    public class GenericInterfaceFinder : IGenericInterfaceFinder
    {
        public IGenericTypesComparer Comparer;
        public IInterfacesExtractor InterfacesExtractor;

        public GenericInterfaceFinder(IGenericTypesComparer comparer, IInterfacesExtractor interfacesExtractor)
        {
            Comparer = comparer;
            InterfacesExtractor = interfacesExtractor;
        }

        public IService FindInterface(IServiceList list, Type @interface)
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

            return null;
        }

        public IEnumerable<IService> FindInterfaces(IServiceList list, Type @interface)
        {
            // return list.GetServices()
            //     .Where(x => x.Registration.Interfaces.Count > 0)
            //     .Where(x => x.Registration.Interfaces.Where(x => x.HasGenericArguments).Any())
            //     .Where(x => x.Registration.Interfaces.Where(x => Comparer.Compare(@interface, x.Type)).Any());


            // TODO provizory
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