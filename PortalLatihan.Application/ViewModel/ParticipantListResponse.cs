using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Application.ViewModel
{
    public class ParticipantListResponse
    {
        public required Guid ID { get; set; }
        public required Guid TicketID { get; set; }
        public required string Name { get; set; }
        public required string IdentityNumber { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Status { get; set; }
        public required bool IsAttended { get; set; }
    }
}