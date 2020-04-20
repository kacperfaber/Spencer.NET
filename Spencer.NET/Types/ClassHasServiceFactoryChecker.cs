using System;
using System.Linq;

namespace Spencer.NET
{
    public class ClassHasServiceFactoryChecker : IClassHasServiceFactoryChecker
    {
        public bool HasFactory(Type @class)
        {
            return @class.GetInterfaces().SingleOrDefault(x => x == typeof(IServiceFactory)) != null;
        }
    }
}