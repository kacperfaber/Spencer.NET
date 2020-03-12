using System;

namespace Odie
{
    public class ServiceGenerator : IServiceGenerator
    {
        public IServiceFlagsGenerator FlagsGenerator;
        
        public Service GenerateService(Type type)
        {
            using ServiceBuilder builder = new ServiceBuilder();

            ServiceFlags flags = FlagsGenerator.GenerateFlags(type);

            throw new NotImplementedException(); //todo
        }
    }
}