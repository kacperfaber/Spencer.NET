using Odie.Commons;

namespace Odie
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder AddInteger(this ModelBuilder builder, string name, int minimum, int maximum)
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
    }
}