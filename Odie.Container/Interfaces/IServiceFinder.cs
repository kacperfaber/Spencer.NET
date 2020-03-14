using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceFinder
    {
        Service Find(ServicesList list, Type typeKey);
    }
}