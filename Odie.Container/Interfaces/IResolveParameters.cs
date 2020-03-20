using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IResolveParameters
    {
        List<IResolveParameter> Parameters { get; set; }
    }
}