using System;
using System.Collections.Generic;

namespace Odie
{
    public class Parameters
    {
        public IEnumerable<Type> Types { get; set; }

        public IEnumerable<object> Values { get; set; }
    }
}