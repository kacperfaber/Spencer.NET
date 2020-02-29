using System;

namespace Odie.Engine.Builders
{
    public class PropertyBuilder : Builder<Property, PropertyBuilder>
    {
        public PropertyBuilder(Property o = default) : base(o)
        {
        }

        public PropertyBuilder AddName(string name)
        {
            return Update(x => x.Name = name);
        }

        public PropertyBuilder AddGenerator(IGenerator generator)
        {
            return Update(x => x.Generator = generator);
        }

        public PropertyBuilder AddExceptedType(Type type)
        {
            return Update(x => x.ExceptedType = type);
        }

        public PropertyBuilder AddExceptedType<T>()
        {
            return Update(x => x.ExceptedType = typeof(T));
        }

        public PropertyBuilder AddGeneratorParameters(GeneratorParameters parameters)
        {
            return Update(x => x.GeneratorParameters = parameters);
        }
    }
}