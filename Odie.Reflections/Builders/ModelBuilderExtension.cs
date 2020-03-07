using System;

namespace Odie
{
    public static class ModelBuilderExtension
    {
        // public IReflectionFieldsGetter ReflectionFieldsGetter;
        // public PropertiesGenerator PropertiesGenerator;
        
        public static ModelBuilder FromType<T>(this ModelBuilder builder) where T : class
        {
            // IEnumerable<ReflectionField> reflectionFields = ReflectionFieldsGetter.Get(typeof(T));
            // IEnumerable<Property> properties = PropertiesGenerator.GenerateProperties(reflectionFields);

            return builder.Update(x => x.Properties.AddRange(null));
        }
        
        public static ModelBuilder FromType(this ModelBuilder builder, Type type)
        {
            // IEnumerable<ReflectionField> reflectionFields = ReflectionFieldsGetter.Get(type);
            // IEnumerable<Property> properties = PropertiesGenerator.GenerateProperties(reflectionFields);

            return builder.Update(x => x.Properties.AddRange(null));
        }
    }
}