﻿using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IReadOnlyContainerResolver
    {
        object Resolve(Type type);

        T Resolve<T>();
        
        T ResolveOrDefault<T>();

        object ResolveOrDefault(Type type);
        
        IEnumerable<T> ResolveMany<T>();

        IEnumerable<object> ResolveMany(Type type);
    }
}