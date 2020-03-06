using System;
using System.Reflection;

namespace Odie.Engine
{
    public class PropertyBuilder : Builder<Property, PropertyBuilder>, IDisposable
    {
        public IDefaultValueGeneratorsProvider ValueGeneratorsProvider;
        
        public PropertyBuilder(Property o = default) : base(o)
        {
        }

        public PropertyBuilder AddName(string name)
        {
            return Update(x => x.Name = name);
        }

        public PropertyBuilder AddValueGeneratorWithType(IValueGenerator valueGenerator)
        {
            return Update(x =>
            {
                x.ValueGenerator = valueGenerator;
                x.ValueGeneratorType = valueGenerator.GetType();
            });
        }

        public PropertyBuilder AddValueGenerator(IValueGenerator valueGenerator)
        {
            return Update(x => x.ValueGenerator = valueGenerator);
        }

        public PropertyBuilder AddValueGeneratorType(Type type)
        {
            return Update(x => x.ValueGeneratorType = type);
        }

        public PropertyBuilder AddValueGeneratorType<T>()
        {
            return Update(x => x.ValueGeneratorType = typeof(T));
        }

        public PropertyBuilder AddExceptedType(Type type)
        {
            return Update(x => x.ExceptedType = type);
        }

        public PropertyBuilder AddExceptedType<T>()
        {
            return Update(x => x.ExceptedType = typeof(T));
        }

        public PropertyBuilder AddParametersWithType(object parameters)
        {
            return Update(x =>
            {
                x.Parameters = parameters;
                x.ParametersType = parameters.GetType();
            });
        }

        public PropertyBuilder AddParameters(object parameters)
        {
            return Update(x => x.Parameters = parameters);
        }

        public PropertyBuilder AddParametersType(Type type)
        {
            return Update(x => x.ParametersType = type);
        }

        public PropertyBuilder AddParametersType<T>()
        {
            return Update(x => x.ParametersType = typeof(T));
        }

        public PropertyBuilder LoadFrom(ReflectionField field)
        {
            if (field.MemberType == MemberType.FIELD)
            {
                return LoadFrom((FieldInfo) field.Instance);
            }

            else if (field.MemberType == MemberType.PROPERTY)
            {
                return LoadFrom((PropertyInfo) field.Instance);
            }
            
            throw new ArgumentException($"{field.GetType().FullName}.{field.MemberType.GetType().Name} cannot be an {MemberType.UNSIGNED.GetType().Name}");
        }

        public PropertyBuilder LoadFrom(PropertyInfo propertyInfo)
        {   
            // NEED TO ADD ARGUMENTS ATTR HERE .::. TODO
            
            Type exceptedType = propertyInfo.PropertyType;
            IValueGenerator valueGenerator = ValueGeneratorsProvider.ProvideGenerator(exceptedType);

            return Update(x =>
            {
                x.Name = propertyInfo.Name;
                x.ExceptedType = exceptedType;
                x.ValueGenerator = valueGenerator;
                x.ValueGeneratorType = valueGenerator.GetType();
            });
        }

        public PropertyBuilder LoadFrom(FieldInfo fieldInfo)
        {
            // TODO argument attrs

            Type exceptedType = fieldInfo.FieldType;
            IValueGenerator generator = ValueGeneratorsProvider.ProvideGenerator(exceptedType);

            return Update(x =>
            {
                x.Name = fieldInfo.Name;
                x.ExceptedType = exceptedType;
                x.ValueGenerator = generator;
                x.ValueGeneratorType = generator.GetType();
            });
        }

        public void Dispose()
        {
        }
    }
}