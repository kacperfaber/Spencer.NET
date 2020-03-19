namespace Odie
{
    public class RegistrationInstanceIsNullChecker : IRegistrationInstanceIsNullChecker
    {
        public bool Check(IServiceRegistration registration)
        {
            return registration.Instance == null;
        }
    }
}