using System.Collections.Generic;

namespace Odie
{
    public interface IParametersValuesGenerator
    {
        IEnumerable<IParameter> Generate(IEnumerable<IParameter> parameters, IContainer container);
    }
}