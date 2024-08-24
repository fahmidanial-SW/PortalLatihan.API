namespace PortalLatihan.Application.ViewModel
{
    public class TicketPriceResponse
    {
        public required decimal TotalFee { get; set; }
        public required decimal DiscountGroup { get; set; }
        public required decimal DiscountCode { get; set; }
        public required decimal FinalFee { get; set; }
    }
}
