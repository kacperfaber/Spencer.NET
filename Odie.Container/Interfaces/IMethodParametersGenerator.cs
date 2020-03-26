using System.Collections.Generic;
using System.Reflection;

namespace Odie
{
    public interface IMethodParametersGenerator
    {
        IEnumerable<IParameter> GenerateParameters(IMember member);
    }
}