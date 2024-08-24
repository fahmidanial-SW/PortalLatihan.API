namespace PortalLatihan.Application.ViewModel
{
    public class TicketPriceCountRequest
    {
        public required Guid TrainingFeeID { get; set; }
        public required int Count { get; set; }
    }
}
