using System.Collections.Generic;

namespace Odie
{
    public interface IDefaultFactoryFinder
    {
        IFactory FindDefaultFactory(IEnumerable<IFactory> factories);
    }
}