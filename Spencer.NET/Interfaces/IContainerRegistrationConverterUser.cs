using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IContainerRegistrationConverterUser
    {
        IEnumerable<IService> UseConverter(IContainerRegistration registration, List<IContainerRegistrationConverter> converters);
    }
}