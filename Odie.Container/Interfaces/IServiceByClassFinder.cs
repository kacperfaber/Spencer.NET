using System;

namespace Odie
{
    public interface IServiceByClassFinder
    {
        Service FindByClass(ServicesList list, Type @class);
    }
}