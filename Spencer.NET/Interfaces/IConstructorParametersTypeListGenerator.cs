using System;
using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IConstructorParametersTypeListGenerator
    {
        List<Type> GenerateList(IConstructorParameters parameters);
    }
}