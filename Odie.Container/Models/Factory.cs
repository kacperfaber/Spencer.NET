using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class Factory : IFactory
    {
        public MemberInfo Member { get; set; }
        public int Type { get; set; }
        public Type ResultType { get; set; }
        
        public IEnumerable<IParameter> MethodParameters { get; set; }
    }
}