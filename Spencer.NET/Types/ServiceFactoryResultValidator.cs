namespace Spencer.NET
{
    public class ServiceFactoryResultValidator : IServiceFactoryResultValidator
    {
        public bool Validate(IServiceFactoryResult factoryResult)
        {
            return factoryResult?.Service?.Registration != null;
        }
    }
}