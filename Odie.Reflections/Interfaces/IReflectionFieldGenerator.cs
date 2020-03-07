using System.Reflection;

namespace Odie
{
    public interface IReflectionFieldGenerator
    {
        ReflectionField Generate(PropertyInfo propertyInfo);

        ReflectionField Generate(FieldInfo fieldInfo);
    }
}