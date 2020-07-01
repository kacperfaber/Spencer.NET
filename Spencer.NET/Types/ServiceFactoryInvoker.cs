using System;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class ServiceFactoryInvoker : IServiceFactoryInvoker
    {
        public IServiceFactoryResult Invoke(IServiceFactory factory)
        {
            try
            {
                Type @interface = typeof(IServiceFactory);
                MethodInfo iMethod = @interface.GetMethods().FirstOrDefault(x => x.ReturnType == typeof(IService));
                MethodInfo method = factory.GetType().GetMethods().SingleOrDefault(x => x.Name == iMethod.Name);
                IService service = (IService) method.Invoke(factory, new object[] { });
                
                return new ServiceFactoryResult(service);
            }

            catch (Exception e)
            {
                return new ServiceFactoryResult(null);
            }
        }
    }
}