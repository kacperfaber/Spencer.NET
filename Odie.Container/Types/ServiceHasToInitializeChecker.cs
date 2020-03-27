namespace Odie
{
    public class ServiceHasToInitializeChecker : IServiceHasToInitializeChecker
    {
        public IAlwaysNewChecker AlwaysNewChecker;

        public ServiceHasToInitializeChecker(IAlwaysNewChecker alwaysNewChecker)
        {
            AlwaysNewChecker = alwaysNewChecker;
        }

        public bool Check(IService service)
        {
            bool alwaysNew = AlwaysNewChecker.Check(service);

            if (alwaysNew)
            {
                return false;
            }

            else
            {
                return service.Data.Instance == null;
            }
        }
    }
}