namespace PortalLatihan.Application.ViewModel
{
    public class ParticipantUpdateRequest
    {
        public required Guid ID { get; set; }
        public required string Name { get; set; }
        public required string IdentityType { get; set; }
        public required string IdentityNum { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }

        public void Validate()
        {
            if (ID == Guid.Empty)
            {
                throw new System.Exception("ID is required");
            }

            if (string.IsNullOrEmpty(Name))
            {
                throw new System.Exception("Name is required");
            }

            if (string.IsNullOrEmpty(IdentityType))
            {
                throw new System.Exception("Identity Type is required");
            }

            if (string.IsNullOrEmpty(IdentityNum))
            {
                throw new System.Exception("Identity Number is required");
            }

            if (string.IsNullOrEmpty(Email))
            {
                throw new System.Exception("Email is required");
            }

            if (string.IsNullOrEmpty(Phone))
            {
                throw new System.Exception("Phone is required");
            }

            if (IdentityType != "NRIC" && IdentityType != "Passport")
            {
                throw new System.Exception("Identity Type must be NRIC or Passport");
            }
        }
    }
}