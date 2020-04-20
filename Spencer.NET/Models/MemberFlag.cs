namespace Spencer.NET
{
    public class MemberFlag
    {
        public const int Field = 0x51;
        public const int Property = 0x85;
        public const int Constructor = 0x100;
        public const int Method = 0x9215;
        public const int Class = 0x512;
        public const int Interface = 0x72;
        public const int Enum = 0x1851;
        public const int Static = 0x024;
        public const int Public = 0x7124;
        public const int Internal = 0x729;
        public const int Private = 0x8124;
        public const int Parametrized = 0x81452;
        public const int GenericParametrized = 0x0214;
        public const int ValueType = 0x251;
        public const int ReferenceType = 0x0251;
        public const int ReturnsValue = 0x824;
        public const int ReturnsVoid = 0x82152;
        public const int NotParametrized = 0x21481452;
        public const int NotGenericParametrized = 0x240214;
    }
}