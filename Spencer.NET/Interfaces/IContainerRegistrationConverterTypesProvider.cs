﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public interface IContainerRegistrationConverterTypesProvider
    {
        IEnumerable<Type> ProvideTypes(Assembly scanningAssembly);
    }
}