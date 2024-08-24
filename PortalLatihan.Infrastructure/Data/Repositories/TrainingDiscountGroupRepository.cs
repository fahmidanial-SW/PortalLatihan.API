using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class TrainingDiscountGroupRepository(PortalLatihanDBContext context) : BaseRepository<TrainingDiscountGroup>(context), ITrainingDiscountGroupRepository
    {
        private readonly PortalLatihanDBContext context = context;

        public async Task<List<TrainingDiscountGroup>> GetListByTrainingID(Guid TrainingID)
        {
            try
            {
                var result = await context.TRAINING_DISCOUNT_GROUP
                    .Where(x => x.TrainingID == TrainingID)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete_ByTrainingID(Guid trainingID)
        {
            try
            {
                var trainingDiscountGroup = await context.TRAINING_DISCOUNT_GROUP
                    .Where(x => x.TrainingID == trainingID)
                    .ToListAsync();

                context.TRAINING_DISCOUNT_GROUP.RemoveRange(trainingDiscountGroup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
