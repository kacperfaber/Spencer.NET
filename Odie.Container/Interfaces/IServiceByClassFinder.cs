using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceByClassFinder
    {
        IService FindByClass(IServiceList list, Type @class);

        IEnumerable<IService> FindManyByClass(IServiceList list, Type @class);
    }
}