using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Entities
{
    public class TrainingDiscountGroup : BaseDomainEntity
    {
        public required Guid TrainingID { get; set; }
        public required int MinParticipant { get; set; }
        public int? MaxParticipant { get; set; }
        public required DiscountTypeEnum DiscountType { get; set; }
        public required decimal Discount { get; set; }

        public void Validate()
        {

            if (TrainingID == Guid.Empty)
            {
                throw new InvalidDataException("Training ID cannot be empty");
            }

            if (MinParticipant <= 0)
            {
                throw new InvalidDataException("Minimum participant must be greater than 0");
            }

            if (MaxParticipant.HasValue && MaxParticipant.Value <= 0)
            {
                throw new InvalidDataException("Maximum participant must be greater than 0");
            }

            if (Discount <= 0)
            {
                throw new InvalidDataException("Discount must be greater than 0");
            }

            if (MaxParticipant.HasValue && MaxParticipant.Value < MinParticipant)
            {
                throw new InvalidDataException("Maximum participant must be greater than or equal to minimum participant");
            }
        }

        public decimal CalculateDiscount(decimal fee)
        {
            if (DiscountType == DiscountTypeEnum.PERCENTAGE)
            {
                return fee * Discount / 100;
            }
            else
            {
                return Discount;
            }

        }
    }
}
