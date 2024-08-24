namespace PortalLatihan.Application.ViewModel
{
    public class TrainingDetailResponse
    {
        public required Guid ZoneID { get; set; }
        public required Guid RegionID { get; set; }
        public required string ZoneName { get; set; }
        public required string RegionName { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set;}
        public required DateTime EventDate { get; set; }
        public required int DurationInDays { get; set; }
        public required int MinParticipant { get; set; }
        public required int MaxParticipant { get; set; }
        public required string Status { get; set; }
    }
}
