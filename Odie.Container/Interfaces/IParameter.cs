﻿using System;

namespace Odie
{
    public interface IParameter
    {
        Type ParameterType { get; set; }
        
        object Value { get; set; }
    }
}