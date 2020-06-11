using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class FactoriesProvider : IFactoriesProvider
    {
        public IFactoryGenerator Generator;

        public FactoriesProvider(IFactoryGenerator generator)
        {
            Generator = generator;
        }

        public IEnumerable<IFactory> ProvideFactories(IEnumerable<ServiceRegistrationFlag> registrationFlags)
        {
            IEnumerable<ServiceRegistrationFlag> factories = registrationFlags
                .Where(x => x.Code == RegistrationFlagConstants.Factory)
                .Where(x => x.Member != null);

            foreach (ServiceRegistrationFlag flag in factories)
            {
                yield return Generator.GenerateFactory(flag.Member);
            }
        }
    }
}