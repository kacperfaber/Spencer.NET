using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IDefaultFactoryFinder
    {
        IFactory FindDefaultFactory(IEnumerable<IFactory> factories);
    }
}