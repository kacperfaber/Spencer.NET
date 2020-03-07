using System.Reflection;

namespace Odie
{
    public class ReflectionFieldGenerator : IReflectionFieldGenerator
    {
        public IFlagsGenerator FlagsGenerator;

        public ReflectionFieldGenerator(IFlagsGenerator flagsGenerator)
        {
            FlagsGenerator = flagsGenerator;
        }

        public ReflectionField Generate(PropertyInfo propertyInfo)
        {
            return new ReflectionField()
            {
                Flags = FlagsGenerator.GenerateFlags(propertyInfo),
                Instance = propertyInfo,
                MemberType = MemberType.PROPERTY,
                Type = propertyInfo.GetType(),
            };
        }

        public ReflectionField Generate(FieldInfo fieldInfo)
        {
            return new ReflectionField()
            {
                Flags = FlagsGenerator.GenerateFlags(fieldInfo),
                Instance = fieldInfo,
                Type = fieldInfo.GetType(),
                MemberType = MemberType.FIELD
            };
        }
    }
}