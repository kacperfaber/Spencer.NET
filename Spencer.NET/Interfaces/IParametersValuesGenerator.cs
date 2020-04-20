using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IParametersValuesGenerator
    {
        IEnumerable<IParameter> Generate(IEnumerable<IParameter> parameters, IReadOnlyContainer container);
    }
}