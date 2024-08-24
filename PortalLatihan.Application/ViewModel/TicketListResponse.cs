using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Application.ViewModel
{
    public class TicketListResponse
    {
        public Guid ID { get; set; }
        public Guid TrainingID { get; set; }
        public required string BuyerName { get; set; } 
        public required int Quantity { get; set; }
        public required decimal Fee { get; set; } 
        public required string Status { get; set; } 

    }
}