using System;

namespace Odie
{
    [MultiInstance]
    public class FieldBuilder : Builder<Field, FieldBuilder>
    {
        public FieldBuilder(Field o = null) : base(o)
        {
        }

        public FieldBuilder AddName(string name)
        {
            return Update(x => x.Name = name);
        }

        public FieldBuilder AddType<T>()
        {
            return Update(x => x.Type = typeof(T));
        }

        public FieldBuilder AddType(Type type)
        {
            return Update(x => x.Type = type);
        }

        public FieldBuilder AddValue(object value)
        {
            return Update(x => x.Value = value);
        }

        public FieldBuilder AddValue<T>(T value)
        {
            return Update(x =>
            {
                x.Value = value;
                x.Type = typeof(T);
            });
        }
        
        public FieldBuilder AddValue(Type type, object value)
        {
            return Update(x =>
            {
                x.Value = value;
                x.Type = type;
            });
        }
    }
}