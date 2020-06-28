using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class DefaultConstructorProvider : IDefaultConstructorProvider
    {
        public IConstructor ProvideDefaultConstructor(IEnumerable<ServiceRegistrationFlag> flags)
        {
            return (IConstructor) flags.SingleOrDefault(x => x.Code == RegistrationFlagConstants.DefaultConstructor).Value;
        }
    }
}