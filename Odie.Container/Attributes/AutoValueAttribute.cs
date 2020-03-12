namespace Odie
{
    public class AutoValueAttribute : ServiceFlagAttribute
    {
        public AutoValueAttribute() : base(ServiceFlagConstants.AutoValue, null)
        {
        }
    }
}