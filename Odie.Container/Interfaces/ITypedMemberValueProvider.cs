﻿using System;

namespace Odie
{
    public interface ITypedMemberValueProvider
    {
        object ProvideValue(Type type, IReadOnlyContainer container);
    }
}