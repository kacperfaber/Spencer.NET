using System.Collections.Generic;
using System.Reflection;

namespace Spencer.NET
{
    public interface IContainerRegistrationConvertersProvider
    {
        List<IContainerRegistrationConverter> ProvideConverters(Assembly assembly);
    }
}