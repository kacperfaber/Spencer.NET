namespace Odie
{
    public class MultiInstanceAttribute : ServiceFlagAttribute
    {
        public MultiInstanceAttribute() : base(ServiceFlagConstants.MultiInstance)
        {
        }
    }
}