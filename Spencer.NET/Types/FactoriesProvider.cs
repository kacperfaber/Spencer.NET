using System.Collections.Generic;

namespace Spencer.NET
{
    public class FactoriesProvider : IFactoriesProvider
    {
        public IFactoryGenerator Generator;

        public FactoriesProvider(IFactoryGenerator generator)
        {
            Generator = generator;
        }

        public IEnumerable<IFactory> ProvideFactories(ServiceFlags flags)
        {
            IEnumerable<ServiceFlag> factories = flags.GetFlags(ServiceFlagConstants.ServiceFactory);

            foreach (ServiceFlag flag in factories)
            {
                yield return Generator.GenerateFactory(flag.Member);
            }
        }
    }
}