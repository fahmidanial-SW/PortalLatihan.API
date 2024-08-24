using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class TrainingStatusHistoryRepository(PortalLatihanDBContext context) : BaseRepository<TrainingStatusHistory>(context), ITrainingStatusHistoryRepository
    {
        private readonly PortalLatihanDBContext context = context;
        public async Task<List<TrainingStatusHistory>> GetListByTrainingID(Guid trainingID)
        {
            return await context.TRAINING_STATUS_HISTORY.Where(x => x.TrainingID == trainingID).ToListAsync();
        }
    }
}

