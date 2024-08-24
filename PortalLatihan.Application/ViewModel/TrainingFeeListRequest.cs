namespace PortalLatihan.Application.ViewModel
{
    public class TrainingFeeListRequest
    {
        public required string ParticipantType { get; set; }
        public required decimal Fee { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(ParticipantType))
            {
                throw new Exception("Participant Type must be provided");
            }

            if (Fee <= 0)
            {
                throw new Exception("Fee must be greater than 0");
            }
        }
    }
}
