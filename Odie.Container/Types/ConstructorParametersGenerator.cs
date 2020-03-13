using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class ConstructorParametersGenerator : IConstructorParametersGenerator
    {
        public IParameterInfoIsValueTypeChecker ValueTypeChecker;
        public IValueTypeActivator ValueTypeActivator;
        public IParameterInfoHasDefaultValueChecker DefaultValueChecker;
        public IParameterInfoDefaultValueProvider DefaultValueProvider;

        public ConstructorParametersGenerator(IParameterInfoDefaultValueProvider defaultValueProvider, IParameterInfoHasDefaultValueChecker defaultValueChecker, IValueTypeActivator valueTypeActivator, IParameterInfoIsValueTypeChecker valueTypeChecker)
        {
            DefaultValueProvider = defaultValueProvider;
            DefaultValueChecker = defaultValueChecker;
            ValueTypeActivator = valueTypeActivator;
            ValueTypeChecker = valueTypeChecker;
        }

        public IEnumerable<object> GenerateParameters(ConstructorInfo constructor, ServiceFlags flags, IContainerResolver resolver, IContainerRegistrar registrar)
        {
            ParameterInfo[] parameters = constructor.GetParameters();

            foreach (ParameterInfo parameter in parameters)
            {
                Type parameterType = parameter.ParameterType;
                
                if (DefaultValueChecker.Check(parameter))
                {
                    yield return DefaultValueProvider.Provide(parameter);
                }
                
                if (ValueTypeChecker.Check(parameter))
                {
                    yield return ValueTypeActivator.ActivateInstance(parameterType);
                }

                if (resolver.Has(parameterType))
                {
                    yield return resolver.Resolve(parameterType);
                }

                else
                {
                    registrar.Register(parameterType);
                    
                    yield return resolver.Resolve(parameterType);
                }
            }
        }
    }
}