namespace PortalLatihan.Domain.Entities
{
    public class RefZone : BaseDomainEntity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Code))
            {
                throw new InvalidDataException("Code is required");
            }

            if (string.IsNullOrEmpty(Name))
            {
                throw new InvalidDataException("Name is required");
            }
        }
    }
}
