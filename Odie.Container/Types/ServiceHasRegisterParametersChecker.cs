namespace Odie
{
    public class ServiceHasRegisterParametersChecker : IServiceHasRegisterParametersChecker
    {
        public bool Check(IService service)
        {
            return service.Registration.RegisterParameter != null;
        }
    }
}