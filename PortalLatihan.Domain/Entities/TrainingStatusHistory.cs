using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Entities
{
    public class TrainingStatusHistory : BaseDomainEntity
    {
        public required Guid TrainingID { get; set; }
        public required TrainingStatusEnum Status { get; set; }
        public string? Remarks { get; set; }

        public void Validate()
        {
            if (TrainingID == Guid.Empty)
            {
                throw new InvalidDataException("Training ID cannot be empty");
            }
        }
    }
}
