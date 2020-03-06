using System.Collections.Generic;

namespace Odie.Reflections
{
    public interface IPropertiesGenerator
    {
        IEnumerable<Property> GenerateProperties(IEnumerable<ReflectionField> fields);
    }
}