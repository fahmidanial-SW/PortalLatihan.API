using System.Text;

namespace PortalLatihan.Application.ViewModel
{
    public class TicketAddRequest
    {
        public required Guid TrainingID { get; set; }
        public required string BuyerEmail { get; set; }
        public required string BuyerName { get; set; }
        public required List<TicketPriceCountRequest> ticketCountList { get; set; }
        public required List<ParticipantListRequest> participantList { get; set; }
        public string? DiscountCode { get; set; }

        public void Validate()
        {
            StringBuilder validationErrors = new ();

            string validationError = validationErrors.ToString();

            if (!string.IsNullOrEmpty(validationError))
            {
                throw new Exception(validationError);
            }
        }

    }
}