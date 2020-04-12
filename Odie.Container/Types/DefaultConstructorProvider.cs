﻿using System;
using System.Linq;
using System.Reflection;

namespace Odie
{
    public class DefaultConstructorProvider : IDefaultConstructorProvider
    {
        public ConstructorInfo ProvideDefaultConstructor(Type type)
        {
            return type
                .GetConstructors()
                .Where(x => x.IsPublic)
                .OrderBy(x => x.GetParameters().Length)
                .First();
        }
    }
}