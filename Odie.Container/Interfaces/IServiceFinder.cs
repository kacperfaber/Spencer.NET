using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceFinder
    {
        Service Find(IEnumerable<Service> services, Type typeKey);
    }
}