using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IContainerRegistrationConverter
    {
    }

    public interface IContainerRegistrationConverter<in TRegistration> : IContainerRegistrationConverter
        where TRegistration : IContainerRegistration, new()
    {
        IEnumerable<IService> Convert(TRegistration registration);
    }
}