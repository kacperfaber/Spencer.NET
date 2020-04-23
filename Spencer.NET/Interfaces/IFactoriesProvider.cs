﻿using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IFactoriesProvider
    {
        IEnumerable<IFactory> ProvideFactories(IService service);
    }
}