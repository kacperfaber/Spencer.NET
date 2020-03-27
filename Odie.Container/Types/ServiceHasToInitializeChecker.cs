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
            bool singleInstance = !AlwaysNewChecker.Check(service);

            return singleInstance && service.Data.Instance == null;
        }
    }
}