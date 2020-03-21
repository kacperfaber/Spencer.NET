using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IConstructorParametersTypeListGenerator
    {
        List<Type> GenerateList(IConstructorParameters parameters);
    }
}