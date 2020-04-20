using System.Reflection;

namespace Spencer.NET
{
    public class MemberGenerator : IMemberGenerator
    {
        public IMemberFlagsGenerator FlagsGenerator;

        public MemberGenerator(IMemberFlagsGenerator flagsGenerator)
        {
            FlagsGenerator = flagsGenerator;
        }

        public IMember GenerateMember(MemberInfo member)
        {
            MemberBuilder builder = new MemberBuilder();

            return builder
                .AddMemberInfo(member)
                .AddFlags(FlagsGenerator.GenerateFlags(member))
                .Build();
        }
    }
}