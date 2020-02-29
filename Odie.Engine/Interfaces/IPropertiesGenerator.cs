using System;
using System.Collections.Generic;

namespace Odie.Engine
{
    public interface IPropertiesGenerator
    {
        IEnumerable<Property> GenerateProperties(Type type);
    }
}