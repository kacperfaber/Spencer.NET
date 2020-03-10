namespace Odie
{
    public class ResultGenerator : IResultGenerator
    {
        public IFieldsGenerator FieldGenerator;
        public ResultBuilder Builder;

        public ResultGenerator(IFieldsGenerator fieldGenerator, ResultBuilder builder)
        {
            FieldGenerator = fieldGenerator;
            Builder = builder;
        }

        public Result Generate(Model model)
        {
            Builder.Clear();

            return Builder
                .AddFields(FieldGenerator.Generate(model.Properties))
                .AddExceptedType(model.ExceptedType)
                .Build();
        }
    }
}