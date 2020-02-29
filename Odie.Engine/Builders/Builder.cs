using System;

namespace Odie.Engine
{
    public class Builder <TOut, TBuilder>
    {
        private TOut Object;

        private TBuilder NewBuilder(TOut o)
        {
            return (TBuilder) Activator.CreateInstance(typeof(TBuilder), o);
        }

        private TOut NewOut()
        {
            return (TOut) Activator.CreateInstance(typeof(TOut));
        }

        public Builder(TOut o = default)
        {
            Object = o == null ? NewOut() : o;
        }

        protected TBuilder Update(Action<TOut> act)
        {
            act(Object);

            return NewBuilder(Object);
        }
        
        public TOut Build()
        {
            return Object;
        }
    }
}