using System;

namespace Odie.Engine
{
    public class GuidGenerator : ValueGenerator
    {
        public GuidGenerator()
        {
            Extensions.Add(new ValueGeneratorExtension()
            {
                Function = (parameters, type) => Guid.NewGuid().ToString(),
                ActivationType = typeof(string)
            });
            
            Extensions.Add(new ValueGeneratorExtension()
            {
                Function = (parameters, type) => Guid.NewGuid(),
                ActivationType = typeof(Guid)
            });
        }
    }
}