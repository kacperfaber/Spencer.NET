using System.Reflection;

namespace Odie.Engine
{
    public class ReflectionFieldGenerator : IReflectionFieldGenerator
    {
        public ReflectionField Generate(PropertyInfo propertyInfo)
        {
            return new ReflectionField()
            {
                Instance = propertyInfo,
                Type = propertyInfo.GetType(),
                MemberType = MemberType.PROPERTY
            };
        }

        public ReflectionField Generate(FieldInfo fieldInfo)
        {
            return new ReflectionField()
            {
                Instance = fieldInfo,
                Type = fieldInfo.GetType(),
                MemberType = MemberType.FIELD
            };
        }
    }
}