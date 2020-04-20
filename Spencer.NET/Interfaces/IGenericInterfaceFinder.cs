using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IGenericInterfaceFinder
    {
        IService FindInterface(IServiceList list, Type @interface);

        IEnumerable<IService> FindInterfaces(IServiceList list, Type @interface);
    }
}