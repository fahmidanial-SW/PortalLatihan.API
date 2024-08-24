using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class RefRegionRepository(PortalLatihanDBContext context) : BaseRepository<RefRegion>(context), IRefRegionRepository
    {
        private readonly PortalLatihanDBContext context = context;

        public async Task<List<RefRegion>> GetListByZoneID(Guid zoneID)
        {
            try
            {
                return await context.REF_REGION.Where(x => x.ZoneID == zoneID).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

