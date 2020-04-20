using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IFactory
    {
        IMember Member { get; set; }
        
        int Type { get; set; }
        
        Type ResultType { get; set; }
        
        IEnumerable<IParameter> MethodParameters { get; set; }
    }
}