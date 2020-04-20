namespace Spencer.NET
{
    public class AutoValueAttribute : ServiceFlagAttribute
    {
        public AutoValueAttribute() : base(ServiceFlagConstants.AutoValue, null)
        {
        }
    }
}