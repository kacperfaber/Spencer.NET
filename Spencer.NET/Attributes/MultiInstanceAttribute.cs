namespace Spencer.NET
{
    public class MultiInstanceAttribute : ServiceFlagAttribute
    {
        public MultiInstanceAttribute() : base(ServiceFlagConstants.MultiInstance)
        {
        }
    }
}