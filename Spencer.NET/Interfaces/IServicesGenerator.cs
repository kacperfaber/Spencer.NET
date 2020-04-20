using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IServicesGenerator
    {
        IEnumerable<IService> GenerateServices(Type type, IAssemblyList assemblies, IReadOnlyContainer container,
            IConstructorParameters constructorParameters = null,
            object instance = null);
    }
}