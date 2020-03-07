﻿using System;
using System.Collections.Generic;
using Odie.Commons;

namespace Odie
{
    public interface IReflectionAttributesFilter
    {
        List<IFilter<Attribute>> Filters { get; set; }

        IEnumerable<Attribute> Filter(IEnumerable<Attribute> attributes);
    }
}