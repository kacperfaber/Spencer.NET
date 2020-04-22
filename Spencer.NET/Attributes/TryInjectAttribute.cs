namespace Spencer.NET
{
    public class TryInjectAttribute : ServiceFlagAttribute
    {
        public TryInjectAttribute() : base(ServiceFlagConstants.TryInject)
        {
        }
    }
}