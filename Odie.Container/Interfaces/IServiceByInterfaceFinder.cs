﻿using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceByInterfaceFinder
    {
        IService FindByInterface(IServiceList list, Type @interface);

        IEnumerable<IService> FindManyByInterface(IServiceList list, Type @interface);
    }
}