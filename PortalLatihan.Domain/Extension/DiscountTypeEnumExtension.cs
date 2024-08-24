using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Extension
{
    public static class DiscountTypeEnumExtension
    {
        public static string ToString(this DiscountTypeEnum discountType)
        {
            return discountType switch
            {
                DiscountTypeEnum.PERCENTAGE => "PERCENTAGE",
                DiscountTypeEnum.NOMINAL => "NOMINAL",
                _ => "Unknown",
            };
        }

        public static DiscountTypeEnum FromString(string discountType)
        {
            return discountType switch
            {
                "PERCENTAGE" => DiscountTypeEnum.PERCENTAGE,
                "NOMINAL" => DiscountTypeEnum.NOMINAL,
                _ => throw new InvalidDataException("Invalid DiscountType")
            };
        }
    }
}
