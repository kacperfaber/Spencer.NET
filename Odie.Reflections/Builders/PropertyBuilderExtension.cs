using System;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public static class PropertyBuilderExtension
    {
        public static PropertyBuilder LoadFrom(this PropertyBuilder builder, ReflectionField field)
        {
            if (field.MemberType == MemberType.FIELD)
            {
                return builder.LoadFrom((FieldInfo) field.Instance);
            }

            else if (field.MemberType == MemberType.PROPERTY)
            {
                return builder.LoadFrom((PropertyInfo) field.Instance);
            }

            throw new ArgumentException($"{field.GetType().FullName}.{field.MemberType.GetType().Name} cannot be an {MemberType.UNSIGNED.GetType().Name}");
        }

        public static PropertyBuilder LoadFrom(this PropertyBuilder builder, PropertyInfo propertyInfo,
            IDefaultValueGeneratorsProvider defaultValueGeneratorsProvider = null,
            IParametersGenerator parametersGenerator = null,
            IFlagsGenerator flagsGenerator = null)
        {
            // container HERE!!! TODO
            Parameters parameters = parametersGenerator.GenerateParameters(propertyInfo);
            Flags flags = flagsGenerator.GenerateFlags(propertyInfo);

            Type exceptedType = propertyInfo.PropertyType;
            IValueGenerator valueGenerator = defaultValueGeneratorsProvider.ProvideGenerator(exceptedType);

            return builder.Update(x =>
            {
                x.Flags = flags;
                x.Parameters = parameters.Values.ToArray();
                x.ParametersType = parameters.Types.ToArray();
                x.Name = propertyInfo.Name;
                x.ExceptedType = exceptedType;
                x.ValueGenerator = valueGenerator;
                x.ValueGeneratorType = valueGenerator.GetType();
            });
        }

        public static PropertyBuilder LoadFrom(this PropertyBuilder builder, FieldInfo fieldInfo,
            IDefaultValueGeneratorsProvider defaultValueGeneratorsProvider = null)
        {
            // TODO 
            // i have to copy LoadFrom (propertyinfo), when container will be ready.

            Type exceptedType = fieldInfo.FieldType;
            IValueGenerator generator = defaultValueGeneratorsProvider.ProvideGenerator(exceptedType);

            return builder.Update(x =>
            {
                x.Name = fieldInfo.Name;
                x.ExceptedType = exceptedType;
                x.ValueGenerator = generator;
                x.ValueGeneratorType = generator.GetType();
            });
        }
    }
}