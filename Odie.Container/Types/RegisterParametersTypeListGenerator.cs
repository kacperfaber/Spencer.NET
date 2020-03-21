using System;
using System.Collections.Generic;
using System.Linq;

namespace Odie
{
    public class RegisterParametersTypeListGenerator : IRegisterParametersTypeListGenerator
    {
        public List<Type> GenerateList(IRegisterParameters parameters)
        {
            IEnumerable<Type> generate(IRegisterParameters p)
            {
                foreach (IRegisterParameter parameter in parameters.Parameters)
                {
                    yield return parameter.Type;
                }
            }

            return generate(parameters).ToList();
        }
    }
}