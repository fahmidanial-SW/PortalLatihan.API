using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Domain.Repositories
{
    public interface IRefRegionRepository : IBaseRepository<RefRegion>
    {
        Task<List<RefRegion>> GetListByZoneID(Guid zoneID);
    }
}
