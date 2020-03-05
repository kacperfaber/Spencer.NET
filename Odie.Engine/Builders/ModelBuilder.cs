using System;
using System.Collections.Generic;

namespace Odie.Engine
{
    public class ModelBuilder : Builder<Model, ModelBuilder>
    {
        public IReflectionFieldsGetter ReflectionFieldsGetter;
        public IPropertiesGenerator PropertiesGenerator;

        public ModelBuilder(Model o = default) : base(o)
        {
            ReflectionFieldsGetter = new ReflectionFieldsGetter(new ReflectionFieldGenerator());
            PropertiesGenerator = new PropertiesGenerator();
        }

        public ModelBuilder(IPropertiesGenerator propertiesGenerator, IReflectionFieldsGetter reflectionFieldsGetter, Model o = null) : base(o)
        {
            // there have to a empty ctor.
            // Factory method are bad idea for it.
            // TODO
            
            PropertiesGenerator = propertiesGenerator;
            ReflectionFieldsGetter = reflectionFieldsGetter;
        }

        public ModelBuilder AddProperty(Property property)
        {
            return Update(x => x.Properties.Add(property));
        }

        public ModelBuilder AddProperties(params Property[] properties)
        {
            return Update(x => x.Properties.AddRange(properties));
        }

        public ModelBuilder FromType<T>() where T : class
        {
            IEnumerable<ReflectionField> reflectionFields = ReflectionFieldsGetter.Get(typeof(T));
            IEnumerable<Property> properties = PropertiesGenerator.GenerateProperties(reflectionFields);

            return Update(x => x.Properties.AddRange(properties));
        }
        
        public ModelBuilder FromType(Type type)
        {
            IEnumerable<ReflectionField> reflectionFields = ReflectionFieldsGetter.Get(type);
            IEnumerable<Property> properties = PropertiesGenerator.GenerateProperties(reflectionFields);

            return Update(x => x.Properties.AddRange(properties));
        }
    }
}