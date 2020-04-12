using System;

namespace Odie
{
    public class ServiceFlagsGenerator : IServiceFlagsGenerator
    {
        public IServiceFlagsProvider FlagsProvider;
        public IServiceFlagsIssuesResolver IssuesResolver;

        public ServiceFlagsGenerator(IServiceFlagsProvider flagsProvider, IServiceFlagsIssuesResolver issuesResolver)
        {
            FlagsProvider = flagsProvider;
            IssuesResolver = issuesResolver;
        }

        public ServiceFlags GenerateFlags(Type type)
        {
            ServiceFlags flags = FlagsProvider.ProvideFlags(type);
            IssuesResolver.ResolveIssues(flags);

            return flags;
        }
    }
}