using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Application.ViewModel
{
    public class TicketDetailResponse
    {
        public required Guid TrainingID { get; set; }
        public Guid? TrainingDiscountCodeID { get; set; }
        public Guid? TrainingDiscountGroupID { get; set; }
        public required string BuyerType { get; set; }
        public required string BuyerName { get; set; }
        public required int Quantity { get; set; }
        public required decimal BaseFee { get; set; }
        public required decimal DiscountedFee { get; set; }
        public required decimal TotalFee { get; set; }
        public string? DiscountDescription { get; set; }
        public required string Status { get; set; }
    }
}
