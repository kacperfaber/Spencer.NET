﻿namespace Spencer.NET
{
    public class AlwaysNewChecker : IAlwaysNewChecker
    {
        public bool Check(IService service)
        {
            return service.Flags.HasFlag(ServiceFlagConstants.MultiInstance);
        }
    }
}