using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public class ContainerRegistrationConvertersCreator : IContainerRegistrationConvertersCreator
    {
        public IContainerRegistrationConverterCreator ConverterCreator;

        public ContainerRegistrationConvertersCreator(IContainerRegistrationConverterCreator converterCreator)
        {
            ConverterCreator = converterCreator;
        }

        public List<IContainerRegistrationConverter> CreateConverters(IEnumerable<Type> convertersType)
        {
            List<IContainerRegistrationConverter> converters = new List<IContainerRegistrationConverter>();

            foreach (Type type in convertersType)
            {
                converters.Add(ConverterCreator.CreateInstance(type));
            }

            return converters;
        }
    }
}