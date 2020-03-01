using System.Reflection;

namespace Odie.Engine
{
    public interface IReflectionFieldGenerator
    {
        ReflectionField Generate(PropertyInfo propertyInfo);

        ReflectionField Generate(FieldInfo fieldInfo);
    }
}