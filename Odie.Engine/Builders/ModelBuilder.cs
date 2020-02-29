namespace Odie.Engine.Builders
{
    public class ModelBuilder : Builder<Model, ModelBuilder>
    {
        public ModelBuilder(Model o = default) : base(o)
        {
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