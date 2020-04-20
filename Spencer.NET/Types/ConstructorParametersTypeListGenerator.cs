using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class ConstructorParametersTypeListGenerator : IConstructorParametersTypeListGenerator
    {
        public List<Type> GenerateList(IConstructorParameters parameters)
        {
            IEnumerable<Type> generate(IConstructorParameters p)
            {
                foreach (IConstructorParameter parameter in parameters.Parameters)
                {
                    yield return parameter.Type;
                }
            }

            return generate(parameters).ToList();
        }
    }
}