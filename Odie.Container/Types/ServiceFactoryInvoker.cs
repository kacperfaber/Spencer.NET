using System;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class ServiceFactoryInvoker : IServiceFactoryInvoker
    {
        public IService Invoke(IServiceFactory factory)
        {
            Type @interface = typeof(IServiceFactory);
            MethodInfo iMethod = @interface.GetMethods().FirstOrDefault(x => x.ReturnType == typeof(IService));
            MethodInfo method = factory.GetType().GetMethods().SingleOrDefault(x => x.Name == iMethod.Name);

            return (IService) method.Invoke(factory, new object[]{});
        }
    }
}