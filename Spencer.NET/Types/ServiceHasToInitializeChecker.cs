namespace Spencer.NET
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
            bool multiInstance = AlwaysNewChecker.Check(service);

            if (multiInstance)
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