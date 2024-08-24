namespace PortalLatihan.Application.ViewModel
{
    public class TrainingFeeListResponse
    {
        public required Guid ID { get; set; }
        public required string ParticipantType { get; set; }
        public required decimal Fee { get; set; }
    }
}
