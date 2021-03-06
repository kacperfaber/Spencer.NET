﻿using System;
using System.Linq;
using System.Reflection;

namespace Spencer.NET
{
    public class DefaultConstructorProvider : IDefaultConstructorProvider
    {
        public IConstructor ProvideDefaultConstructor(IService service)
        {
            return (IConstructor) service.Registration.RegistrationFlags.First(x => x.Code == RegistrationFlagConstants.DefaultConstructor).Value;
        }
    }
}