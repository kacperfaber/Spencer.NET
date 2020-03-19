using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceByInterfaceFinder
    {
        IService FindByInterface(ServicesList list, Type @interface);

        IEnumerable<IService> FindManyByInterface(ServicesList list, Type @interface);
    }
}