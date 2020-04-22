namespace Spencer.NET
{
    public class ServiceFlagConstants
    {
        public const string TryInject = "try_inject";
        public const string Auto = "auto";
        public const string Instance = "singleton_instance";
        public const string MultiInstance = "multi_instance";
        public const string AutoValue = "auto_value";
        public const string SingleInstance = "single_instance";
        public const string AlwaysNew = "always_new";
        public const string ExcludeType = "exclude_type";
        public const string ServiceCtor = "service_constructor";
        public const string ServiceFactory = "service_factory";
        public const string Inject = "inject";

        public ServiceFlagConstants()
        {
        }
    }
}