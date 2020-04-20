using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IRegistrationInterfacesFilter
    {
        IEnumerable<Type> Filter(Type[] interfaces);
    }
}