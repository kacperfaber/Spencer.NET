namespace Spencer.NET
{
    public class ServiceIsAutoValueChecker : IServiceIsAutoValueChecker
    {
        public bool Check(IService service)
        {
            return service.Flags.HasFlag(ServiceFlagConstants.AutoValue);
        }
    }
}