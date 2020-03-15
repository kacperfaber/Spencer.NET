﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public class ConstructorParametersGenerator : IConstructorParametersGenerator
    {
        public ITypeIsValueTypeChecker ValueTypeChecker;
        public IValueTypeActivator ValueTypeActivator;
        public IParameterInfoHasDefaultValueChecker DefaultValueChecker;
        public IParameterInfoDefaultValueProvider DefaultValueProvider;

        public ConstructorParametersGenerator(IParameterInfoDefaultValueProvider defaultValueProvider, IParameterInfoHasDefaultValueChecker defaultValueChecker,
            IValueTypeActivator valueTypeActivator, ITypeIsValueTypeChecker valueTypeChecker)
        {
            DefaultValueProvider = defaultValueProvider;
            DefaultValueChecker = defaultValueChecker;
            ValueTypeActivator = valueTypeActivator;
            ValueTypeChecker = valueTypeChecker;
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
    }
}