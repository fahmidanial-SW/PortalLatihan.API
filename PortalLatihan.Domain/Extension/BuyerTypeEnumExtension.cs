using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Extension
{
    public static class BuyerTypeEnumExtension
    {
        public static string ToString(this BuyerTypeEnum buyerType)
        {
            return buyerType switch
            {
                BuyerTypeEnum.INDIVIDUAL => "Individual",
                BuyerTypeEnum.COMPANY => "Company",
                _ => "Unknown",
            };
        }

        public static BuyerTypeEnum FromString(string buyerType)
        {
            return buyerType switch
            {
                "Individual" => BuyerTypeEnum.INDIVIDUAL,
                "Company" => BuyerTypeEnum.COMPANY,
                _ => throw new InvalidDataException("Invalid BuyerType"),
            };
        }
    }
}
