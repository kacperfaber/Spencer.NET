using System.Reflection;

namespace Odie.Reflections
{
    public interface IReflectionFieldGenerator
    {
        ReflectionField Generate(PropertyInfo propertyInfo);

        ReflectionField Generate(FieldInfo fieldInfo);
    }
}