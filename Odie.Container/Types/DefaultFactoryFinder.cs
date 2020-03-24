using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class DefaultFactoryFinder : IDefaultFactoryFinder
    {
        public IFactory FindDefaultFactory(IEnumerable<IFactory> factories)
        {
            throw new NotImplementedException();
        }
    }
}