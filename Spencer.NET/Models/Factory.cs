using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class Factory : IFactory
    {
        public IMember Member { get; set; }
        public int Type { get; set; }
        public Type ResultType { get; set; }
        
        public IEnumerable<IParameter> MethodParameters { get; set; }
    }
}