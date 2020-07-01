﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class ContainerRegistrationConvertersProvider : IContainerRegistrationConvertersProvider
    {
        public IContainerRegistrationConvertersCreator ConvertersCreator;
        public IContainerRegistrationConverterTypesProvider TypesProvider;

        public ContainerRegistrationConvertersProvider(IContainerRegistrationConverterTypesProvider typesProvider, IContainerRegistrationConvertersCreator convertersCreator)
        {
            TypesProvider = typesProvider;
            ConvertersCreator = convertersCreator;
        }

        public List<IContainerRegistrationConverter> ProvideConverters(Assembly assembly)
        {
            IEnumerable<Type> converterTypes = TypesProvider.ProvideTypes(assembly);

            return ConvertersCreator.CreateConverters(converterTypes);
        }
    }
}