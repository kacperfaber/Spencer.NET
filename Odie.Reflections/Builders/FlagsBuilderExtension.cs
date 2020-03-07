namespace Odie
{
    public static class FlagsBuilderExtension
    {
        public static FlagsBuilder AddFlagBy(this FlagsBuilder builder, FlagAttribute attribute)
        {
            Flag flag = new Flag
            {
                Name = attribute.Name,
                Value = attribute.Value
            };

            return builder.AddFlag(flag);
        }
    }
}