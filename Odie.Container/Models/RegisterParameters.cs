using System;
using System.Collections.Generic;

namespace Odie
{
    public class RegisterParameters : IRegisterParameters
    {
        public List<IRegisterParameter> Parameters { get; set; }

        public RegisterParameters()
        {
            Parameters = new List<IRegisterParameter>();
        }

        public void Add(IRegisterParameter p)
        {
            Parameters.Add(p);
        }
    }
}