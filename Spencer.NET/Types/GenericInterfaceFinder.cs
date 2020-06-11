using System;
using System.Collections.Generic;
using System.Linq;
using Spencer.NET.Extensions;

namespace Spencer.NET
{
    public class GenericInterfaceFinder : IGenericInterfaceFinder
    {
        public IGenericTypesComparer Comparer;

        public GenericInterfaceFinder(IGenericTypesComparer comparer)
        {
            Comparer = comparer;
        }

        public IService FindInterface(IServiceList list, Type @interface)
        {
            List<IService> services = list.GetServices();

            throw new NotImplementedException();
        }

        public IEnumerable<IService> FindInterfaces(IServiceList list, Type @interface)
        {
            return list.GetServices()
                .Where(x => x.Registration.Interfaces.Count > 0)
                .Where(x => x.Registration.Interfaces.Where(x => x.HasGenericArguments).Any())
                .Where(x => x.Registration.Interfaces.Where(x => Comparer.Compare(@interface, x.Type)).Any());
        }
    }
}