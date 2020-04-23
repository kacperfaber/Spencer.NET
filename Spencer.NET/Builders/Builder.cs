﻿using System;

 namespace Spencer.NET
{
    public partial class Builder<TOut, TBuilder>
    {
        public TOut Object;

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

        public TBuilder If(bool condition, Action<TOut> action)
        {
            if (condition)
            {
                return Update(action);
            }

            return Update(x => { });
        }

        public TBuilder If(bool condition, Func<TBuilder, TBuilder> func)
        {
            if (condition)
            {
                return func(NewBuilder(Object));
            }

            return Update(_ => { });
        }

        public TOut Build()
        {
            return Object;
        }
    }
}