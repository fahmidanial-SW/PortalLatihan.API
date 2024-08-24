using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Application.ViewModel
{
    public class TrainingDiscountCodeListRequest
    {
        public required string Code { get; set; }
        public required string DiscountType { get; set; }
        public required decimal Discount { get; set; }
        public required int Quota { get; set; }
        public required bool IsUsableWithGroupDiscount { get; set; } = false;

        public void Validate()
        {
            if (string.IsNullOrEmpty(Code))
            {
                throw new Exception("Code is required");
            }

            if (string.IsNullOrEmpty(DiscountType))
            {
                throw new Exception("DiscountType is required");
            }

            if (DiscountType != "PERCENTAGE" && DiscountType != "NOMINAL")
            {
                throw new Exception("DiscountType must be either PERCENTAGE or NOMINAL.");
            }

            if (Discount <= 0)
            {
                throw new Exception("Discount must be greater than 0");
            }

            if (Quota <= 0)
            {
                throw new Exception("Quota must be greater than 0");
            }
        }
    }
}
