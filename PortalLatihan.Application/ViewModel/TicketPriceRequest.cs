namespace PortalLatihan.Application.ViewModel
{
    public class TicketPriceRequest
    {
        public required Guid TrainingID { get; set; }
        public required List<TicketPriceCountRequest> ticketCountList { get; set; }
        public string? DiscountCode { get; set; }   
    }
}
