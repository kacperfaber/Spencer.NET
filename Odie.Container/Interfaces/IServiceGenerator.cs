using System;

namespace Odie
{
    public interface IServiceGenerator
    {
        IService GenerateService(Type @class, IContainer container, object instance = null, IConstructorParameters constructorParameters = null);
    }
}