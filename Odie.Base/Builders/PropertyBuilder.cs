using System;

namespace Odie
{
    public partial class PropertyBuilder : Builder<Property, PropertyBuilder>, IDisposable
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
                x.Parameters = new object[] {parameters};
                x.ParametersType = new Type[]
                {
                    parameters.GetType()
                };
            });
        }

        public PropertyBuilder AddParameters(object parameters)
        {
            return Update(x => x.Parameters[0] = parameters);
        }

        public PropertyBuilder AddParametersType(Type type)
        {
            return Update(x => x.ParametersType[0] = type);
        }

        public PropertyBuilder AddParametersType<T>()
        {
            return Update(x => x.ParametersType[0] = typeof(T));
        }

        // TODO PARTIAL to REFLECTIONS 


        public void Dispose()
        {
        }
    }
}