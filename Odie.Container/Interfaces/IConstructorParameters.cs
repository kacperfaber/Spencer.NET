using System.Collections.Generic;

namespace Odie
{
    public interface IConstructorParameters
    {
        List<IConstructorParameter> Parameters { get; set; }
    }
}