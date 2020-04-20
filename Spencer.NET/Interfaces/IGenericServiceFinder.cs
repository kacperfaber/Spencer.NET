using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IGenericServiceFinder
    {
        IEnumerable<IService> FindGenericServices(IServiceList list, Type type);
    }
}