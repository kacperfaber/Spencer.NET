using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IContainerRegistrationConvertersCreator
    {
        List<IContainerRegistrationConverter> CreateConverters(IEnumerable<Type> convertersType);
    }
}