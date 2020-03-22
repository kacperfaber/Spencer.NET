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
        public IParameterInfoHasDefaultValueChecker DefaultValueChecker;
        public IParameterInfoDefaultValueProvider DefaultValueProvider;
        public IConstructorParameterByTypeFinder ConstructorParameterByTypeFinder;

        public ConstructorParametersGenerator(IParameterInfoDefaultValueProvider defaultValueProvider, IParameterInfoHasDefaultValueChecker defaultValueChecker,
            IValueTypeActivator valueTypeActivator, ITypeIsValueTypeChecker valueTypeChecker, IConstructorParameterByTypeFinder constructorParameterByTypeFinder)
        {
            DefaultValueProvider = defaultValueProvider;
            DefaultValueChecker = defaultValueChecker;
            ValueTypeActivator = valueTypeActivator;
            ValueTypeChecker = valueTypeChecker;
            ConstructorParameterByTypeFinder = constructorParameterByTypeFinder;
        }

        public IEnumerable<object> GenerateParameters(ConstructorInfo constructor, ServiceFlags flags, IContainer container)
        {
            ParameterInfo[] parameters = constructor.GetParameters();

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

        public IEnumerable<object> GenerateParameters(ConstructorInfo constructor, IContainer container)
        {
            foreach (ParameterInfo parameter in constructor.GetParameters())
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