using System;

namespace Odie
{
    public class ModelBuilder : Builder<Model, ModelBuilder>
    {
        public ModelBuilder(Model model = null) : base(model)
        {
        }

        public ModelBuilder AddExceptedType<T>()
        {
            return Update(x => x.ExceptedType = typeof(T));
        }

        public ModelBuilder AddExceptedType(Type type)
        {
            return Update(x => x.ExceptedType = type);
        }

        public ModelBuilder AddProperty(Property property)
        {
            return Update(x => x.Properties.Add(property));
        }

        public ModelBuilder AddProperties(params Property[] properties)
        {
            return Update(x => x.Properties.AddRange(properties));
        }
    }
}