using System;

namespace Odie
{
    public partial class ValueGeneratorBuilder : Builder<ValueGenerator, ValueGeneratorBuilder>
    {
        public ValueGeneratorBuilder AddExtension(Type activationType, Func<object, Type, object> func)
        {
            return Update(x => x.Extensions.Add(new ValueGeneratorExtension()
            {
                Function = func,
                ActivationType = activationType
            }));
        }
        
        public ValueGeneratorBuilder AddExtension<TActivation>(Func<object, Type, object> func)
        {
            return Update(x => x.Extensions.Add(new ValueGeneratorExtension()
            {
                Function = func,
                ActivationType = typeof(TActivation)
            }));
        }
    }
}