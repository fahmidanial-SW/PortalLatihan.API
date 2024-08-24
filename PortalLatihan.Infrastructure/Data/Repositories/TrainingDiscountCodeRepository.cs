using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class TrainingDiscountCodeRepository(PortalLatihanDBContext context) : BaseRepository<TrainingDiscountCode>(context), ITrainingDiscountCodeRepository
    {
        private readonly PortalLatihanDBContext context = context;

        public async Task<List<TrainingDiscountCode>> GetListByTrainingID(Guid TrainingID)
        {
            try
            {
                var result = await context.TRAINING_DISCOUNT_CODE
                    .Where(x => x.TrainingID == TrainingID)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TrainingDiscountCode> GetByTrainingIDAndCode(Guid trainingID, string code)
        {
            try
            {
                var result = await context.TRAINING_DISCOUNT_CODE
                    .Where(x => x.TrainingID == trainingID && x.Code == code)
                    .FirstOrDefaultAsync();

                if (result == null)
                {
                    throw new Exception("Discount Code not found");
                }

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
                var trainingDiscountCode = await context.TRAINING_DISCOUNT_CODE
                    .Where(x => x.TrainingID == trainingID)
                    .ToListAsync();

                context.TRAINING_DISCOUNT_CODE.RemoveRange(trainingDiscountCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
