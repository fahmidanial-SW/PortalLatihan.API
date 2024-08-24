using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Extension
{
    public static class IdentityTypeEnumExtension
    {
        public static string ToString(this IdentityTypeEnum identityTypeEnum)
        {
            return identityTypeEnum switch
            {
                IdentityTypeEnum.NRIC => "NRIC",
                IdentityTypeEnum.PASSPORT => "PASSPORT",
                _ => "Unknown"
            };
        }

        public static IdentityTypeEnum FromString(string identityType)
        {
            return identityType switch
            {
                "NRIC" => IdentityTypeEnum.NRIC,
                "PASSPORT" => IdentityTypeEnum.PASSPORT,
                _ => throw new InvalidDataException("Invalid IdentityType")
            };
        }
    }
}
