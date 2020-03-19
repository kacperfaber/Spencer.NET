using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceByClassFinder
    {
        IService FindByClass(ServicesList list, Type @class);

        IEnumerable<IService> FindManyByClass(ServicesList list, Type @class);
    }
}