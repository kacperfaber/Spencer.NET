﻿using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class ConstructorParametersGenerator : IConstructorParametersGenerator
    {
        public IConstructorParameterByTypeFinder ConstructorParameterByTypeFinder;
        public ITypedMemberValueProvider ValueProvider;
        public IServiceHasConstructorParametersChecker ServiceHasConstructorParametersChecker;

        public ConstructorParametersGenerator(ITypedMemberValueProvider valueProvider, IConstructorParameterByTypeFinder constructorParameterByTypeFinder,
            IServiceHasConstructorParametersChecker serviceHasConstructorParametersChecker)
        {
            ValueProvider = valueProvider;
            ConstructorParameterByTypeFinder = constructorParameterByTypeFinder;
            ServiceHasConstructorParametersChecker = serviceHasConstructorParametersChecker;
        }

        public IEnumerable<IParameter> GenerateParameters(IConstructor constructor, ServiceFlags flags, IReadOnlyContainer container)
        {
            foreach (IParameter parameter in constructor.Parameters)
            {
                object val = ValueProvider.ProvideValue(parameter.Type, container);
                parameter.Value = val;

                yield return parameter;
            }
        }

        public IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IReadOnlyContainer container)
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

        public IEnumerable<object> GenerateParameterValues(IConstructor constructor, IConstructorInstanceCreator instanceCreator)
        {
            foreach (IParameter parameter in constructor.Parameters)
            {
                yield return instanceCreator.CreateInstance(parameter.Type);
            }
        }

        public IEnumerable<IParameter> GenerateParameters(IConstructor constructor, IService service, IReadOnlyContainer container)
        {
            // TODO another dependency LIKE SMART PARAMETERS GENERATOR in dependent to service ctor parameters.
            // LIKE

            if (ServiceHasConstructorParametersChecker.Check(service))
            {
                object constructorParameters = service.Registration.RegistrationFlags
                    .SingleOrDefault(x => x.Code == RegistrationFlagConstants.ConstructorParameters).Value;

                return GenerateParameters(constructor, constructorParameters as IConstructorParameters);
            }

            else
            {
                return GenerateParameters(constructor, container);
            }
        }
    }
}