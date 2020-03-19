using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IGenericServiceFinder
    {
        IEnumerable<IService> FindGenericServices(ServicesList list, Type type);
    }
}