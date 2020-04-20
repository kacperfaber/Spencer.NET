using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IConstructorParameters
    {
        List<IConstructorParameter> Parameters { get; set; }
    }
}