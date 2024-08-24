using PortalLatihan.Domain.Enum;
using System.Net.Http.Headers;

namespace PortalLatihan.Domain.Entities
{
    public class TicketStatusHistory : BaseDomainEntity
    {
        public required Guid TicketID { get; set; }
        public required TicketStatusEnum Status { get; set; }
        public string? Remarks { get; set; }
        public void Validate()
        {
            if (TicketID == Guid.Empty)
            {
                throw new InvalidDataException("Ticket ID is required");
            }
        }
    }
}
