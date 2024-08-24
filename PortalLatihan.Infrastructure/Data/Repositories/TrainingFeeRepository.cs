using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class TrainingFeeRepository(PortalLatihanDBContext context) : BaseRepository<TrainingFee>(context), ITrainingFeeRepository
    {
        private readonly PortalLatihanDBContext context = context;

        public async Task Delete_ByTrainingID(Guid trainingID)
        {
            try
            {
                var trainingFee = await context.TRAINING_FEE.Where(x => x.TrainingID == trainingID).ToListAsync();
                context.TRAINING_FEE.RemoveRange(trainingFee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingFee>> List_ByTrainingID(Guid trainingID)
        {
            try
            {
                return await context.TRAINING_FEE.Where(x => x.TrainingID == trainingID).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
