using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IMethodParametersGenerator
    {
        IEnumerable<IParameter> GenerateParameters(IMember member);
    }
}