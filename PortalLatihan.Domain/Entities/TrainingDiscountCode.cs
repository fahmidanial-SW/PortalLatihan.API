using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Entities
{
    public class TrainingDiscountCode : BaseDomainEntity
    {
        public required Guid TrainingID { get; set; }
        public required string Code { get; set; }
        public required DiscountTypeEnum DiscountType { get; set; }
        public required decimal Discount { get; set; }
        public decimal? MaxDiscount { get; set; }
        public required int Quota { get; set; }
        public int BalanceQuota { get; private set; } 
        public required bool IsUsableWithGroupDiscount { get; set; }
        public DateTime? ExpiredDate { get; set; }

        public TrainingDiscountCode()
        {
            BalanceQuota = Quota;
        }

        public void Validate()
        {
            if (TrainingID == Guid.Empty)
            {
                throw new InvalidDataException("Training ID cannot be empty");
            }

            if (string.IsNullOrEmpty(Code))
            {
                throw new InvalidDataException("Code cannot be empty");
            }

            if (Discount <= 0)
            {
                throw new InvalidDataException("Discount must be greater than 0");
            }

            if (Quota <= 0)
            {
                throw new InvalidDataException("Quota must be greater than 0");
            }

            if (ExpiredDate.HasValue && ExpiredDate.Value < DateTime.Now)
            {
                throw new InvalidDataException("Expired date must be greater than current date");
            }
        }

        public decimal CalculateDiscount(decimal fee, decimal groupDiscountFee)
        {
            //if (BalanceQuota <= 0)
            //{
            //    throw new Exception("Quota is empty");
            //}

            if (ExpiredDate.HasValue && ExpiredDate.Value < DateTime.Now)
            {
                throw new Exception("Discount code is expired");
            }

            if (!IsUsableWithGroupDiscount && groupDiscountFee > 0)
            {
                throw new Exception("Discount code cannot be used with group discount");
            }

            if (DiscountType == DiscountTypeEnum.PERCENTAGE)
            {
                return (fee - groupDiscountFee) * Discount / 100;
            }
            else
            {
                return Discount;
            }
        }
    }
}
