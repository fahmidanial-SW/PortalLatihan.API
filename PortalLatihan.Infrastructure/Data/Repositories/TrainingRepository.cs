using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Enum;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class TrainingRepository(PortalLatihanDBContext context) : BaseRepository<Training>(context), ITrainingRepository
    {
        private readonly PortalLatihanDBContext context = context;

        public async Task<TrainingStatusEnum> GetStatusByID(Guid ID)
        {
            var result = await context.TRAINING.FindAsync(ID);

            return result == null ? throw new Exception("Training not found") : result.Status;
        }

        public async Task<List<Training>> GetListByZoneAndRegion(Guid? ZoneID, Guid? RegionID)
        {
            try
            {
                var query = context.TRAINING.AsQueryable();

                if (ZoneID != null)
                {
                    query = query.Where(x => x.ZoneID == ZoneID);
                }

                if (RegionID != null)
                {
                    query = query.Where(x => x.RegionID == RegionID);
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Training>> GetListByStatus(TrainingStatusEnum status)
        {
            try
            {
                return await context.TRAINING.Where(x => x.Status == status).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Training>> GetListByUser(string user)
        {
            try
            {
                return await context.TRAINING.Where(x => x.SysUserCreated == user).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Training>> GetListByAvailable()
        {
            try
            {
                return await context.TRAINING.Where(x => x.EventDate >= DateTime.Now && x.Status == TrainingStatusEnum.APPROVED).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

