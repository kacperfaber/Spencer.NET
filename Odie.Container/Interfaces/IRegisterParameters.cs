using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IRegisterParameters
    {
        List<IRegisterParameter> Parameters { get; set; }
    }
}