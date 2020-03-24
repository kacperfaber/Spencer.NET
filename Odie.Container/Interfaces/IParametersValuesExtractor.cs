using System.Collections.Generic;

namespace Odie
{
    public interface IParametersValuesExtractor
    {
        object[] ExtractValues(IEnumerable<IParameter> parameters);
    }
}