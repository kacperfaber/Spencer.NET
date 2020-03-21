using System;

namespace Odie
{
    public interface IConstructorInstanceCreator
    {
        object CreateInstance(ServiceFlags flags, Type @class, IContainer container);

        object CreateInstance(Type @class, IContainer container);
        
        object CreateInstance(Type @class, IConstructorParameters constructorParameter);
    }
}