using System;
using System.Collections.Generic;

namespace Odie
{
    public class ResultBuilder : Builder<Result, ResultBuilder>
    {
        public ResultBuilder(Result o = null) : base(o)
        {
        }

        public ResultBuilder AddField(Field field)
        {
            return Update(x => x.Fields.Add(field));
        }

        public ResultBuilder AddField(Action<FieldBuilder> action)
        {
            FieldBuilder builder = new FieldBuilder();

            action.Invoke(builder);

            return Update(x => x.Fields.Add(builder.Build()));
        }

        public ResultBuilder AddFields(params Field[] fields)
        {
            return Update(x => x.Fields.AddRange(fields));
        }
        
        public ResultBuilder AddFields(IEnumerable<Field> fields)
        {
            return Update(x => x.Fields.AddRange(fields));
        }

        public ResultBuilder AddExceptedType(Type type)
        {
            return Update(x => x.ExceptedType = type);
        }

        public ResultBuilder AddExceptedType<T>()
        {
            return Update(x => x.ExceptedType = typeof(T));
        }
    }
}