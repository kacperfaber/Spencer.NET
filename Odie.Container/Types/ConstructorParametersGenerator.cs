using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorParametersGenerator : IConstructorParametersGenerator
    {
        public ITypeIsValueTypeChecker ValueTypeChecker;
        public IValueTypeActivator ValueTypeActivator;
        public IParameterHasDefaultValueChecker DefaultValueChecker;
        public IParameterInfoDefaultValueProvider DefaultValueProvider;
        public IConstructorParameterByTypeFinder ConstructorParameterByTypeFinder;

        public ConstructorParametersGenerator(IParameterInfoDefaultValueProvider defaultValueProvider, IParameterHasDefaultValueChecker defaultValueChecker,
            IValueTypeActivator valueTypeActivator, ITypeIsValueTypeChecker valueTypeChecker, IConstructorParameterByTypeFinder constructorParameterByTypeFinder)
        {
            DefaultValueProvider = defaultValueProvider;
            DefaultValueChecker = defaultValueChecker;
            ValueTypeActivator = valueTypeActivator;
            ValueTypeChecker = valueTypeChecker;
            ConstructorParameterByTypeFinder = constructorParameterByTypeFinder;
        }

        public IEnumerable<object> GenerateParameters(IConstructor constructor, ServiceFlags flags, IContainer container)
        {
            // TODO replace with IParameter
            
            ParameterInfo[] parameters = constructor.Parameters;

            foreach (ParameterInfo parameter in parameters)
            {
                Type parameterType = parameter.ParameterType;

                if (DefaultValueChecker.Check(parameter))
                {
                    yield return DefaultValueProvider.Provide(parameter);
                    continue;
                }

                if (ValueTypeChecker.Check(parameterType))
                {
                    yield return ValueTypeActivator.ActivateInstance(parameterType);
                    continue;
                }

                if (container.Has(parameterType))
                {
                    yield return container.Resolve(parameterType);
                    continue;
                }

                else
                {
                    container.Register(parameterType);

                    yield return container.Resolve(parameterType);
                    continue;
                }
            }
        }

        public IEnumerable<object> GenerateParameters(IConstructor constructor, IContainer container)
        {
            foreach (ParameterInfo parameter in constructor.Parameters)
            {
                yield return container.Resolve(parameter.ParameterType);
            }
        }

        public IEnumerable<object> GenerateParameters(IConstructor constructor, IConstructorParameters constructorParameters)
        {
            foreach (ParameterInfo parameter in constructor.Parameters)
            {
                IConstructorParameter constructorParameter = ConstructorParameterByTypeFinder.FindByType(constructorParameters, parameter.ParameterType);

                yield return constructorParameter.Value;
                constructorParameters.Parameters.Remove(constructorParameter);
            }
        }
    }
}