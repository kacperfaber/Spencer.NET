namespace Odie
{
    public class ServiceHasConstructorParametersChecker : IServiceHasConstructorParametersChecker
    {
        public bool Check(IService service)
        {
            return service.Registration.ConstructorParameter != null;
        }
    }
}