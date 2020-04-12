using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServicesGenerator
    {
        IEnumerable<IService> GenerateServices(Type type, IAssemblyList assemblies, IReadOnlyContainer container,
            IConstructorParameters constructorParameters = null,
            object instance = null);
    }
}