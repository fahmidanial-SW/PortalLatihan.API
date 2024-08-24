using PortalLatihan.Domain.Repositories;

namespace PortalLatihan.Domain.Entities
{
    public class RefRegion : BaseDomainEntity
    {
        public required Guid ZoneID { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }

        public void Validate()
        {
            if (ZoneID == Guid.Empty)
            {
                throw new InvalidDataException("ZoneID is required");
            }

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
