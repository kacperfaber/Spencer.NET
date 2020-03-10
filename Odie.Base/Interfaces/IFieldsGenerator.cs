using System.Collections.Generic;

namespace Odie
{
    public interface IFieldsGenerator
    {
        IEnumerable<Field> Generate(IEnumerable<Property> properties);
    }
}