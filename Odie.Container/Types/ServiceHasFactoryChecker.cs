﻿namespace Odie
{
    public class ServiceHasFactoryChecker : IServiceHasFactoryChecker
    {
        public bool Check(IService service)
        {
            return service.Flags.HasFlag(ServiceFlagConstants.ServiceFactory);
        }
    }
}