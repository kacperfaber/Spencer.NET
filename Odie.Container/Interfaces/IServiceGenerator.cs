using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IServiceGenerator
    {
        IEnumerable<IService> GenerateServices(Type type, IAssemblyList assemblies, IContainer container, IRegisterParameters registerParameters = null,
            object instance = null);
    }
}