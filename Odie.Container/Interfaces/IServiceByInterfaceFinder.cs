using System;

namespace Odie
{
    public interface IServiceByInterfaceFinder
    {
        IService FindByInterface(ServicesList list, Type @interface);
    }
}