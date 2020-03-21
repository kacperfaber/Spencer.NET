using System;
using System.Collections.Generic;

namespace Odie
{
    public interface IRegisterParametersTypeListGenerator
    {
        List<Type> GenerateList(IRegisterParameters parameters);
    }
}