using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IContainerRegistrationConverter<in TRegistration> 
        where TRegistration : IContainerRegistration
    {
        IEnumerable<IService> Convert(TRegistration registration);
    }
}