namespace Odie
{
    public class SingleInstanceAttribute : ServiceFlagAttribute
    {
        public SingleInstanceAttribute() : base(ServiceFlagConstants.SingleInstance, null)
        {
        }
    }
}