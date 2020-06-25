using System.Collections.Generic;

namespace Spencer.NET
{
    public interface IContainerRegistrationConvertersProvider
    {
        List<IContainerRegistrationConverter> ProvideConverters();
    }
}