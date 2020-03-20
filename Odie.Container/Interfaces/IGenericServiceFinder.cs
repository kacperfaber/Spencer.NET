using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IGenericServiceFinder
    {
        IEnumerable<IService> FindGenericServices(IServiceList list, Type type);
    }
}