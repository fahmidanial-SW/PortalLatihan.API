namespace PortalLatihan.Application.ViewModel
{
    public class TrainingDiscountCodeListResponse
    {
        public required Guid ID { get; set; }
        public required string Code { get; set; }
        public required string DiscountType { get; set; }
        public required decimal Discount { get; set; }
        public required int Quota { get; set; }
        public required Guid TrainingID { get; set; }
    }
}
