using System;
using Odie.Commons;

namespace Odie
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder AddInteger(this ModelBuilder builder, string name, int minimum = 0, int maximum = 100)
        {
            Property property = new PropertyBuilder()
                .AddName(name)
                .InjectValueGenerator<IntegerGenerator>()
                .AddParametersWithType(new Range(minimum, maximum))
                .Build();

            return builder.AddProperty(property);
        }

        public static ModelBuilder AddBool(this ModelBuilder builder, string name, float @true = .5f)
        {
            Property property = new PropertyBuilder()
                .AddName(name)
                .AddParametersWithType(@true)
                .AddExceptedType<bool>()
                .InjectValueGenerator<BooleanGenerator>()
                .Build();

            return builder.AddProperty(property);
        }

        public static ModelBuilder AddGuid<T>(this ModelBuilder builder, string name)
        {
            Property property = new PropertyBuilder()
                .AddName(name)
                .AddExceptedType<T>()
                .InjectValueGenerator<GuidGenerator>()
                .Build();

            return builder.AddProperty(property);
        }

        public static ModelBuilder AddGuid(this ModelBuilder builder, string name)
        {
            Property property = new PropertyBuilder()
                .AddName(name)
                .AddExceptedType<Guid>()
                .InjectValueGenerator<GuidGenerator>()
                .Build();

            return builder.AddProperty(property);
        }

        public static ModelBuilder AddFloat(this ModelBuilder builder, string name, float minimum = 0f, float maximum = 100f)
        {
            PropertyBuilder propertyBuilder = StaticContainer.Current.Resolve<PropertyBuilder>();

            Property property = propertyBuilder
                .AddName(name)
                .AddExceptedType<float>()
                .AddParameters(new Range<float>(maximum, maximum))
                .AddParametersType<Range<float>>()
                .Build();

            return builder.AddProperty(property);
        }

        public static ModelBuilder AddDouble(this ModelBuilder builder, string name, double minimum = 0d, double maximum = 100D)
        {
            PropertyBuilder propertyBuilder = StaticContainer.Current.Resolve<PropertyBuilder>();

            Property property = propertyBuilder
                .AddName(name)
                .AddExceptedType<double>()
                .AddParameters(new Range<double>(minimum, maximum))
                .AddParametersType<double>()
                .Build();

            return builder.AddProperty(property);
        }

        public static ModelBuilder AddLong(this ModelBuilder builder, string name, long minimum = 0L, long maximum = 100L)
        {
            PropertyBuilder propertyBuilder = StaticContainer.Current.Resolve<PropertyBuilder>();

            Property property = propertyBuilder
                .AddName(name)
                .AddExceptedType<long>()
                .AddParameters(new Range<long>(minimum, maximum))
                .AddParametersType<long>()
                .Build();

            return builder.AddProperty(property);
        }

        public static ModelBuilder AddRange<T>(this ModelBuilder builder, string name, T minimum, T maximum)
        {
            return builder.Update(x => {});
            
            PropertyBuilder propertyBuilder = StaticContainer.Current.Resolve<PropertyBuilder>();

            Property property = propertyBuilder
                .AddName(name)
                .AddExceptedType<T>()
                .AddParameters(new Range<T>(minimum, maximum))
                .AddParametersType<T>()
                .Build();

            return builder.AddProperty(property);
        }
        
        public static ModelBuilder AddDateTime<T>(this ModelBuilder builder, string name, DateTimeKind kind)
        {
            PropertyBuilder propertyBuilder = StaticContainer.Current.Resolve<PropertyBuilder>();

            Property property = propertyBuilder
                .AddName(name)
                .AddValueGenerator(new DateTimeGenerator())
                .AddValueGeneratorType<DateTimeGenerator>()
                .AddParameters(new DateTimeParameter() {Kind = kind})
                .AddParametersType<DateTimeParameter>()
                .AddExceptedType<T>()
                .Build();

            return builder.AddProperty(property);
        }
    }
}