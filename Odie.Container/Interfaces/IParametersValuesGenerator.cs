using System.Collections.Generic;

namespace Odie
{
    public interface IParametersValuesGenerator
    {
        void Generate(IEnumerable<IParameter> parameters, IContainer container);
    }
}