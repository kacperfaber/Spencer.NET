using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceGenerator
    {
        Service GenerateService(Type type, object instance = null);
    }
}