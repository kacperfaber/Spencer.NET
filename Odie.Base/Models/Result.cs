using System;
using System.Collections.Generic;

namespace Odie
{
    public class Result
    {
        public Type ExceptedType { get; set; }
        
        public List<Field> Fields { get; set; }

        public Result()
        {
            Fields = new List<Field>();
        }
    }
}