using System;
using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public interface IDefaultConstructorProvider
    {
        IConstructor ProvideDefaultConstructor(IEnumerable<ServiceRegistrationFlag> flags);
    }
}