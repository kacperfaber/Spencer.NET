namespace Odie
{
    public class AlwaysNewChecker : IAlwaysNewChecker
    {
        public bool Check(Service service)
        {
            return service.Flags.HasFlag(ServiceFlagConstants.MultiInstance);
        }
    }
}