﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IFactory
    {
        IMember Member { get; set; }
        
        int Type { get; set; }
        
        Type ResultType { get; set; }
        
        IEnumerable<IParameter> MethodParameters { get; set; }
    }
}