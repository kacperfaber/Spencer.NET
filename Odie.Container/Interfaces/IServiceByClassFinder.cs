using System;

namespace Odie
{
    public interface IServiceByClassFinder
    {
        IService FindByClass(ServicesList list, Type @class);
    }
}