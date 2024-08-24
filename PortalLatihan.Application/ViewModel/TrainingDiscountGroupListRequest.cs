namespace PortalLatihan.Application.ViewModel
{
    public class TrainingDiscountGroupListRequest
    {
        public required int MinParticipant { get; set; }
        public int? MaxParticipant { get; set; }
        public required string DiscountType { get; set; }
        public required decimal Discount { get; set; }

        public void Validate()
        {

            if (DiscountType != "PERCENTAGE" && DiscountType != "NOMINAL")
            {
                throw new Exception("DiscountType must be either PERCENTAGE or NOMINAL.");
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

            if (Discount < 0) {
                throw new Exception("Discount must be greater than 0.");
            }
        }
    }
}
