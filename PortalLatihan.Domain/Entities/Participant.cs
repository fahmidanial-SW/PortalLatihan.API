using PortalLatihan.Domain.Enum;
using PortalLatihan.Domain.Validator;

namespace PortalLatihan.Domain.Entities
{
    public class Participant : BaseDomainEntity
    {
        public required Guid TicketID { get; set; }
        public required Guid TrainingFeeID { get; set; }
        public required string Name { get; set; }
        public required IdentityTypeEnum IdentityType { get; set; }
        public required string IdentityNum { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public ParticipantStatusEnum Status { get; private set; }
        public bool IsAttended { get; private set; }

        public Participant()
        {
            Status = ParticipantStatusEnum.REGISTERED;
            IsAttended = false;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new InvalidDataException("Name is required");
            }

            if (string.IsNullOrEmpty(IdentityNum))
            {
                throw new InvalidDataException("Identity Number is required");
            }

            if (string.IsNullOrEmpty(Email))
            {
                throw new InvalidDataException("Email is required");
            }

            if (EmailValidator.IsValidEmail(Email))
            {
                throw new InvalidDataException("Email is not valid");
            }

            if (string.IsNullOrEmpty(Phone))
            {
                throw new InvalidDataException("Phone is required");
            }

            if (TicketID == Guid.Empty)
            {
                throw new InvalidDataException("Ticket ID is required");
            }
        }

        public void ChangeStatusToPaid()
        {
            if (Status != ParticipantStatusEnum.REGISTERED)
            {
                throw new InvalidDataException("Participant status is not REGISTERED");
            }

            Status = ParticipantStatusEnum.PAID;
        }

        public void ChangeStatusToAttended()
        {
            if (IsAttended) {
                throw new InvalidDataException("Participant is already attended");
            }

            IsAttended = true;
        }

        public void ChangeStatusToAbsent()
        {
            if (!IsAttended) {
                throw new InvalidDataException("Participant is already absent");
            }

            IsAttended = false;
        }

        public void ChangeStatusToCancelled()
        {
            if (Status != ParticipantStatusEnum.REGISTERED)
            {
                throw new InvalidDataException("Participant status is not REGISTERED");
            }

            Status = ParticipantStatusEnum.CANCELLED;
        }
    }
}
