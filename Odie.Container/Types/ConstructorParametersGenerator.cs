﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ConstructorParametersGenerator : IConstructorParametersGenerator
    {
        public IConstructorParameterByTypeFinder ConstructorParameterByTypeFinder;
        public ITypedMemberValueProvider ValueProvider;
        public IServiceHasConstructorParametersChecker ServiceHasConstructorParametersChecker;

        public ConstructorParametersGenerator(ITypedMemberValueProvider valueProvider, IConstructorParameterByTypeFinder constructorParameterByTypeFinder, IServiceHasConstructorParametersChecker serviceHasConstructorParametersChecker)
        {
            ValueProvider = valueProvider;
            ConstructorParameterByTypeFinder = constructorParameterByTypeFinder;
            ServiceHasConstructorParametersChecker = serviceHasConstructorParametersChecker;
        }

        public IEnumerable<IParameter> GenerateParameters(IConstructor constructor, ServiceFlags flags, IContainer container)
        {
            foreach (IParameter parameter in constructor.Parameters)
            {
                object val = ValueProvider.ProvideValue(parameter.Type, container);
                parameter.Value = val;

                yield return parameter;
            }
        }

        public IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IContainer container)
        {
            foreach (IParameter parameter in constructor.Parameters)
            {
                object val = ValueProvider.ProvideValue(parameter.Type, container);
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

        public IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IService service, IContainer container)
        {
            // TODO another dependency LIKE SMART PARAMETERS GENERATOR in dependent to service ctor parameters.
            // LIKE
            
            if (ServiceHasConstructorParametersChecker.Check(service))
            {
                return GenerateParameters(constructor, service.Registration.ConstructorParameter);
            }

            else
            {
                return GenerateParameters(constructor, container);
            }
        }
    }
}