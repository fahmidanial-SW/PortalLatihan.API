namespace PortalLatihan.Application.ViewModel
{
    public class TrainingDiscountGroupListResponse
    {
        public required Guid ID { get; set; }
        public required int MinParticipant { get; set; }
        public int? MaxParticipant { get; set; }
        public required string DiscountType { get; set; }
        public required decimal Discount { get;  set; }
    }
}
