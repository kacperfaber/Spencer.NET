﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Spencer.NET
{
    public class FactoriesByTypeFilter : IFactoriesByTypeFilter
    {
        public IAssignableChecker AssignableChecker;

        public FactoriesByTypeFilter(IAssignableChecker assignableChecker)
        {
            AssignableChecker = assignableChecker;
        }

        public IEnumerable<IFactory> Filter(Type targetType, IEnumerable<IFactory> factories)
        {
            return factories
                .Where(x => !AssignableChecker.Check(x.ResultType, typeof(ValueType)))
                .Where(x => x.ResultType != typeof(void))
                .Where(x => AssignableChecker.Check(x.ResultType, targetType));
        }
    }
}