using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IGenericClassFinder
    {
        IService FindClass(IServiceList list, Type @class);
        
        IEnumerable<IService> FindClasses(IServiceList list, Type @class);
    }
}