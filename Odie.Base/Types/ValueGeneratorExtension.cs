using System;

namespace Odie
{
    public class ValueGeneratorExtension
    {
        public Type ActivationType { get; set; }

        /// <summary>
        /// <returns>Value object</returns>
        /// <typeparam>Parameters</typeparam>
        /// <typeparam>Parameters type</typeparam>
        /// </summary>
        public Func<object, Type, object> Function { get; set; }
    }
}