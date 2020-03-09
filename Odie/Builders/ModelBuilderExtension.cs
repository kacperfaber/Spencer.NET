using System;
using Odie.Commons;

namespace Odie
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder AddInteger(this ModelBuilder builder, string name, int minimum = 0, int maximum = 1)
        {
            Property property = new PropertyBuilder()
                .AddName(name)
                .UseValueGenerator<IntegerGenerator>()
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
                .UseValueGenerator<BooleanGenerator>()
                .Build();

            return builder.AddProperty(property);
        }

        public static ModelBuilder AddGuid<T>(this ModelBuilder builder, string name)
        {
            Property property = new PropertyBuilder()
                .AddName(name)
                .AddExceptedType<T>()
                .UseValueGenerator<GuidGenerator>()
                .Build();

            return builder.AddProperty(property);
        }
        
        public static ModelBuilder AddGuid(this ModelBuilder builder, string name)
        {
            Property property = new PropertyBuilder()
                .AddName(name)
                .AddExceptedType<Guid>()
                .UseValueGenerator<GuidGenerator>()
                .Build();

            return builder.AddProperty(property);
        }
    }
}