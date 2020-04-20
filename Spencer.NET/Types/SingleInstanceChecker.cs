namespace Spencer.NET
{
    public class SingleInstanceChecker : ISingleInstanceChecker
    {
        public bool Check(IService service)
        {
            return service.Flags.HasFlag(ServiceFlagConstants.SingleInstance);
        }
    }
}