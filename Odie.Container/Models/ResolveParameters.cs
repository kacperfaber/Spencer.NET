using System;
using System.Collections.Generic;

namespace Odie
{
    public class ResolveParameters : IResolveParameters
    {
        public List<IResolveParameter> Parameters { get; set; }

        public ResolveParameters()
        {
            Parameters = new List<IResolveParameter>();
        }

        public void Add(IResolveParameter p)
        {
            Parameters.Add(p);
        }
    }
}