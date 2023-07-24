using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public class ConstructorGenerator : IConstructorGenerator
    {
        public IParametersGenerator ParametersGenerator;

        public ConstructorGenerator(IParametersGenerator parametersGenerator)
        {
            ParametersGenerator = parametersGenerator;
        }

        /// <summary>
        /// Makes IConstructor using given ConstructorInfo, or null when constructor given is null.
        /// </summary>
        /// <param name="constructor"></param>
        /// <returns>null, if 'constructor' given is null.</returns>
        public IConstructor GenerateConstructor(ConstructorInfo constructor)
        {
            if (constructor == null) return null;
            
            var parameters = ParametersGenerator.GenerateParameters(constructor.GetParameters());
            
            return new ConstructorBuilder()
                .AddInstance(constructor)
                .AddParameters(parameters)
                .Build();
        }
    }
}