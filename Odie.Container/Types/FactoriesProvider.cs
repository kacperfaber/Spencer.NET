using System;
using System.Collections.Generic;

namespace Odie
{
    public class FactoriesProvider : IFactoriesProvider
    {
        public IFactoryGenerator Generator;

        public FactoriesProvider(IFactoryGenerator generator)
        {
            Generator = generator;
        }

        public IEnumerable<IFactory> ProvideFactories(IService service)
        {
            IEnumerable<ServiceFlag> factoriesFlags = service.Flags.GetFlags(ServiceFlagConstants.ServiceFactory);

            foreach (ServiceFlag flag in factoriesFlags)
            {
                yield return Generator.GenerateFactory(flag.Parent);
            }
        }
    }
}