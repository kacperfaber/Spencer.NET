using System;

namespace Odie
{
    public interface IServiceByInterfaceFinder
    {
        Service FindByInterface(ServicesList list, Type @interface);
    }
}