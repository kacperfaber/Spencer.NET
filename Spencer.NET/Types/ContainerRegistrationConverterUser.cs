using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class ContainerRegistrationConverterUser : IContainerRegistrationConverterUser
    {
        public IEnumerable<IService> UseConverter(IContainerRegistration registration, List<IContainerRegistrationConverter> converters)
        {
            Type genericConverterType = typeof(IContainerRegistrationConverter<>).MakeGenericType(registration.GetType());
            object converter = converters.FirstOrDefault(x=>genericConverterType.IsAssignableFrom(x.GetType()));

            return (IEnumerable<IService>) genericConverterType
                .GetMethods()
                .FirstOrDefault(x => x.Name == "Convert")
                .Invoke(converter, new[] {registration});
        }
    }
}