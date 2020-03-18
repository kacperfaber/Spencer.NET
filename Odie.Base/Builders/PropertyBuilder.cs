using System;

namespace Odie
{
    [MultiInstance]
    public class PropertyBuilder : Builder<Property, PropertyBuilder>, IDisposable
    {
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

        public PropertyBuilder InjectValueGenerator<T>()
        {
            T resolved = StaticContainer.Current.Resolve<T>();
            IValueGenerator valueGenerator = resolved as IValueGenerator;

            return AddValueGenerator(valueGenerator).AddValueGeneratorType(valueGenerator.GetType());
        }
        
        public PropertyBuilder InjectValueGenerator(Type type)
        {
            IValueGenerator generator = StaticContainer.Current.Resolve(type) as IValueGenerator;

            return AddValueGeneratorWithType(generator);
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
                x.Parameters.Add(parameters);
                x.ParametersType.Add(parameters.GetType());
            });
        }

        public PropertyBuilder AddParameters(object parameters)
        {
            return Update(x => x.Parameters.Add(parameters));
        }

        public PropertyBuilder AddParametersType(Type type)
        {
            return Update(x => x.ParametersType.Add(type));
        }

        public PropertyBuilder AddParametersType<T>()
        {
            return Update(x => x.ParametersType.Add(typeof(T)));
        }

        public void Dispose()
        {
        }
    }
}