using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Application.ViewModel
{
    public class TrainingListResponse
    {
        public required Guid ID { get; set; }
        public required string ZoneName { get; set; }
        public required string RegionName { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string DateRange { get; set; }
        public required int DurationInDays { get; set; }
        public required string Fee { get; set; }
        public required string Status { get; set; }
        public required int ParticipantRegisteredCount { get; set; }
        public required int ParticipantPaidCount { get; set; }
        public required int ParticipantAttendedCount { get; set; }
        public required int TicketBookedCount { get; set; }
        public required int TicketPaidCount { get; set; }
    }
}
