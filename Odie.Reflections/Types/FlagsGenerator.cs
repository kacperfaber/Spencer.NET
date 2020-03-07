using System;
using System.Reflection;

namespace Odie
{
    public class FlagsGenerator : IFlagsGenerator
    {
        public IFlagAttributeTypeProvider FlagAttributeTypeProvider;
        public IFlagGenerator FlagGenerator;

        public FlagsGenerator(IFlagGenerator flagGenerator, IFlagAttributeTypeProvider flagAttributeTypeProvider)
        {
            FlagGenerator = flagGenerator;
            FlagAttributeTypeProvider = flagAttributeTypeProvider;
        }

        public Flags GenerateFlags(MemberInfo member)
        {
            FlagsBuilder builder = new FlagsBuilder();
            Attribute[] attributes = Attribute.GetCustomAttributes(member, FlagAttributeTypeProvider.ProvideType());

            foreach (Attribute attribute in attributes)
            {
                Flag flag = FlagGenerator.GenerateFlag(attribute);

                builder.AddFlag(flag);
            }

            return builder.Build();
        }
    }
}