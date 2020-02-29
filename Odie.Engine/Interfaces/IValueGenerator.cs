﻿using System;

namespace Odie.Engine
{
    public interface IValueGenerator
    {
        object Generate(object parameters, Type parametersType, Type exceptedType, ref Type valueType);
    }
}