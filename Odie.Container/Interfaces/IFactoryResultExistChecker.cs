﻿using System.Reflection;

namespace Odie
{
    public interface IFactoryResultExistChecker
    {
        bool Check(MemberInfo member);
    }
}