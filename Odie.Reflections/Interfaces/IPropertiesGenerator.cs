using System.Collections.Generic;

namespace Odie
{
    public interface IPropertiesGenerator
    {
        IEnumerable<Property> GenerateProperties(IEnumerable<ReflectionField> fields);
    }
}