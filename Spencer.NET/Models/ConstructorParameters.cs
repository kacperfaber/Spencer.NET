using System.Collections.Generic;

namespace Spencer.NET
{
    public class ConstructorParameters : IConstructorParameters
    {
        public List<IConstructorParameter> Parameters { get; set; }

        public ConstructorParameters()
        {
            Parameters = new List<IConstructorParameter>();
        }

        public void Add(IConstructorParameter p)
        {
            Parameters.Add(p);
        }
    }
}