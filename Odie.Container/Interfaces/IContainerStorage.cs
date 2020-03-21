using System.Collections.Generic;

namespace Odie
{
    public interface IContainerStorage
    {
        IStorage Storage { get; set; }
    }
}