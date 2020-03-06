using System;

namespace Odie
{
    public partial class Builder <TOut, TBuilder>
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

        public TBuilder Update(Action<TOut> act)
        {
            act(Object);

            return NewBuilder(Object);
        }

        public TBuilder Clear()
        {
            return NewBuilder(NewOut());
        }
        
        public TOut Build()
        {
            return Object;
        }
    }
}