using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceFinder
    {
        IService Find(ServicesList list, Type typeKey);
    }
}