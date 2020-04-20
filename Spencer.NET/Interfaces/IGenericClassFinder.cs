using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IGenericClassFinder
    {
        IService FindClass(IServiceList list, Type @class);
        
        IEnumerable<IService> FindClasses(IServiceList list, Type @class);
    }
}