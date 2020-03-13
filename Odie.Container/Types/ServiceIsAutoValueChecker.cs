namespace Odie
{
    public class ServiceIsAutoValueChecker : IServiceIsAutoValueChecker
    {
        public bool Check(Service service)
        {
            return service.Flags.HasFlag(ServiceFlagConstants.AutoValue);
        }
    }
}