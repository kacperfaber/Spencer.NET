using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceFinder
    {
        IService Find(IServiceList list, Type typeKey);

        IEnumerable<IService> FindMany(IServiceList list, Type type);
    }
}