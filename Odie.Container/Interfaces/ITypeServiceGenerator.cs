﻿using System;

namespace Odie
{
    public interface ITypeServiceGenerator
    {
        IService GenerateService(Type @class, IContainer container, object instance = null, IRegisterParameters registerParameters = null);
    }
}