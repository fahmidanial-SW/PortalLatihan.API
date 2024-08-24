using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Entities
{
    public class Training : BaseDomainEntity
    {
        public required Guid ZoneID { get; set; }
        public required Guid RegionID { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set;}
        public required string Location { get; set; }
        public required DateTime EventDate { get; set; }
        public required int DurationInDays { get; set; }
        public required int MinParticipant { get; set; }
        public required int MaxParticipant { get; set; }
        public TrainingStatusEnum Status { get; private set; }

        public Training()
        {
           Status = TrainingStatusEnum.PENDING_APPROVAL;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Title))
            {
                throw new InvalidDataException("Title must be set");
            }

            if (string.IsNullOrEmpty(Description))
            {
                throw new InvalidDataException("Description must be set");
            }

            if (string.IsNullOrEmpty(Location))
            {
                throw new InvalidDataException("Location must be set");
            }

            if (EventDate < DateTime.Now)
            {
                throw new InvalidDataException("Event Date must be in the future");
            }

            if (DurationInDays < 0)
            {
                throw new InvalidDataException("Duration must be greater than 0");
            }

            if (MinParticipant < 0)
            {
                throw new InvalidDataException("Minimum Participant must be greater than 0");
            }

            if (MaxParticipant < MinParticipant) {
                throw new InvalidDataException("Maximum Participant must be greater than Minimum Participant");
            }

            if (ID == Guid.Empty)
            {
                throw new InvalidDataException("ID must be set");
            }

            if (SysDateCreated == null)
            {
                throw new InvalidDataException("SysDateCreated must be set");
            }

            if (SysDateModified == null)
            {
                throw new InvalidDataException("SysDateLastModified must be set");
            }

            if (SysUserCreated == null)
            {
                throw new InvalidDataException("SysUserLastModified must be set");
            }

            if (SysUserModified == null)
            {
                throw new InvalidDataException("SysUserLastModified must be set");
            }
        }

        public void Approve()
        {
            if(Status != TrainingStatusEnum.PENDING_APPROVAL)
            {
                throw new Exception("Only Pending Approval Training can be approved");
            }

            Status = TrainingStatusEnum.APPROVED;
        }

        public void Reject()
        {
            if (Status != TrainingStatusEnum.PENDING_APPROVAL)
            {
                throw new  Exception("Only Pending Approval Training can be rejected");
            }

            Status = TrainingStatusEnum.REJECTED;
        }

        public void ReSubmit()
        {
            if (Status != TrainingStatusEnum.REJECTED)
            {
                throw new Exception("Only Rejected Training can be resubmitted");
            }

            Status = TrainingStatusEnum.PENDING_APPROVAL;
        }
    }
}
