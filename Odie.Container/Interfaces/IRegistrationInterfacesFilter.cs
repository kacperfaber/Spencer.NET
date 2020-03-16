using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IRegistrationInterfacesFilter
    {
        IEnumerable<Type> Filter(Type[] interfaces);
    }
}