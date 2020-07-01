using System;

namespace Spencer.NET
{
    public class Builder<TOut, TBuilder, TBuildOutput> where TOut : TBuildOutput
    {
        public TOut Object;

        private TBuilder NewBuilder(TOut o)
        {
            return (TBuilder) (this as object);
        }

        private TOut NewOut()
        {
            return (TOut) Activator.CreateInstance(typeof(TOut));
        }

        public Builder(TOut o = default)
        {
            Object = o == null ? NewOut() : o;
        }

        public TBuilder Update(Action<TOut> act)
        {
            act(Object);

            return NewBuilder(Object);
        }

        public virtual TBuildOutput Build()
        {
            return Object;
        }
    }
}