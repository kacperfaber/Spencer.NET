﻿namespace Spencer.NET
{
    public class ServiceDataInstanceIsNullChecker : IServiceDataInstanceIsNullChecker
    {
        public bool Check(IService service)
        {
            return service.Data.Instance == null;
        }
    }
}