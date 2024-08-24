using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Application.ViewModel
{
    public class TrainingDiscountGroupUpdateRequest {
        public required Guid ID { get; set; }
        public required Guid TrainingID { get; set; }
        public required int MinParticipant { get; set; }
        public int? MaxParticipant { get; set; }
        public required string DiscountType { get; set; }
        public required decimal Discount { get; set; }

        public void Validate()
        {
            if (TrainingID == Guid.Empty)
            {
                throw new Exception("TrainingID must be provided.");
            }

            if (DiscountType != "PERCENTAGE" && DiscountType != "NOMINAL")
            {
                throw new Exception("DiscountType must be either Percentage or Nominal.");
            }

            if (DiscountType == "PERCENTAGE" && (Discount < 0 || Discount > 100))
            {
                throw new Exception("Discount must be between 0 and 100 for Percentage DiscountType.");
            }

            if (DiscountType == "NOMINAL" && Discount < 0)
            {
                throw new Exception("Discount must be greater than 0 for Nominal DiscountType.");
            }

            if (MinParticipant < 1)
            {
                throw new Exception("MinParticipant must be greater than 0.");
            }

            if (MaxParticipant != null && MaxParticipant < MinParticipant)
            {
                throw new Exception("MaxParticipant must be greater than or equal to MinParticipant.");
            }

            if (Discount < 0)
            {
                throw new Exception("Discount must be greater than 0.");
            }
        }

        public DiscountTypeEnum GetDiscountTypeEnum()
        {
            return DiscountType switch
            {
                "PERCENTAGE" => DiscountTypeEnum.PERCENTAGE,
                "NOMINAL" => DiscountTypeEnum.NOMINAL,
                _ => throw new Exception("Invalid DiscountType")
            };
        }
    }
}
