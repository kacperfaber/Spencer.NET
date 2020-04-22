namespace Spencer.NET
{
    public class AutoAttribute : ServiceFlagAttribute
    {
        public AutoAttribute() : base(ServiceFlagConstants.Auto)
        {
        }
    }
}