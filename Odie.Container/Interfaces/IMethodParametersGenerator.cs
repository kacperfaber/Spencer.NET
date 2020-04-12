using System.Collections.Generic;

namespace Odie
{
    public interface IMethodParametersGenerator
    {
        IEnumerable<IParameter> GenerateParameters(IMember member);
    }
}