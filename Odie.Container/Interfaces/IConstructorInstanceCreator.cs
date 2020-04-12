﻿using System;

namespace Odie
{
    public interface IConstructorInstanceCreator
    {
        object CreateInstance(ServiceFlags flags, Type @class, IReadOnlyContainer container);

        object CreateInstance(Type @class, IReadOnlyContainer container);
        
        object CreateInstance(Type @class, IConstructorParameters constructorParameters);
    }
}