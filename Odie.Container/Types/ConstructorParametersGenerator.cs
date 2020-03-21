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
        public IRegisterParameterByTypeFinder RegisterParameterByTypeFinder;

        public ConstructorParametersGenerator(IParameterInfoDefaultValueProvider defaultValueProvider, IParameterInfoHasDefaultValueChecker defaultValueChecker,
            IValueTypeActivator valueTypeActivator, ITypeIsValueTypeChecker valueTypeChecker, IRegisterParameterByTypeFinder registerParameterByTypeFinder)
        {
            DefaultValueProvider = defaultValueProvider;
            DefaultValueChecker = defaultValueChecker;
            ValueTypeActivator = valueTypeActivator;
            ValueTypeChecker = valueTypeChecker;
            RegisterParameterByTypeFinder = registerParameterByTypeFinder;
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

        public IEnumerable<object> GenerateParameters(ConstructorInfo constructor, IRegisterParameters registerParameters)
        {
            ParameterInfo[] parameters = constructor.GetParameters();

            foreach (ParameterInfo parameter in parameters)
            {
                IRegisterParameter registerParameter = RegisterParameterByTypeFinder.FindByType(registerParameters, parameter.ParameterType);

                yield return registerParameter.Value;
                registerParameters.Parameters.Remove(registerParameter);
            }
        }
    }
}