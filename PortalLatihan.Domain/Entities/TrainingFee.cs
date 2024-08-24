namespace PortalLatihan.Domain.Entities
{
    public class TrainingFee : BaseDomainEntity
    {
        public required Guid TrainingID { get; set; }
        public required string ParticipantType { get; set; }
        public required decimal Fee { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(ParticipantType))
            {
                throw new InvalidDataException("Participant Type must be set");
            }

            if (Fee < 0)
            {
                throw new InvalidDataException("Fee must be equal or greater than 0");
            }
        }
    }
}
