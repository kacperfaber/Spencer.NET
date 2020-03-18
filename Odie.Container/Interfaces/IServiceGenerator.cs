using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceGenerator
    {
        IEnumerable<IService> GenerateServices(Type type, AssemblyList assemblies, IContainer container, object instance = null);
    }
}