using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IParametersValuesExtractor
    {
        object[] ExtractValues(IEnumerable<IParameter> parameters);
    }
}