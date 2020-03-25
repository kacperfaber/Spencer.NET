using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorParametersGenerator : IConstructorParametersGenerator
    {
        public IConstructorParameterByTypeFinder ConstructorParameterByTypeFinder;
        public IParameterValueProvider ValueProvider;

        public ConstructorParametersGenerator(IParameterValueProvider valueProvider, IConstructorParameterByTypeFinder constructorParameterByTypeFinder)
        {
            ValueProvider = valueProvider;
            ConstructorParameterByTypeFinder = constructorParameterByTypeFinder;
        }

        public IEnumerable<IParameter> GenerateParameters(IConstructor constructor, ServiceFlags flags, IContainer container)
        {
            foreach (IParameter parameter in constructor.Parameters)
            {
                object val = ValueProvider.ProvideValue(parameter, container);
                parameter.Value = val;

                yield return parameter;
            }
        }

        public IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IContainer container)
        {
            foreach (IParameter parameter in constructor.Parameters)
            {
                object val = ValueProvider.ProvideValue(parameter, container);
                parameter.Value = val;

                yield return parameter;
            }
        }

        public IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IConstructorParameters constructorParameters)
        {
            foreach (IParameter parameter in constructor.Parameters)
            {
                IConstructorParameter constructorParameter = ConstructorParameterByTypeFinder.FindByType(constructorParameters, parameter.Type);
                parameter.Value = constructorParameter.Value;

                yield return parameter;
            }
        }
    }
}