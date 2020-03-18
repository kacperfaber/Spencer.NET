using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceGenerator
    {
        IEnumerable<Service> GenerateServices(Type type, AssemblyList assemblies, IContainer container, object instance = null);
    }
}