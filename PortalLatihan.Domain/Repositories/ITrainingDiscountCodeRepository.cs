using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Domain.Repositories
{
    public interface ITrainingDiscountCodeRepository : IBaseRepository<TrainingDiscountCode>
    {
        Task<TrainingDiscountCode> GetByTrainingIDAndCode(Guid trainingID, string code);
        Task<List<TrainingDiscountCode>> GetListByTrainingID(Guid ID);
        Task Delete_ByTrainingID(Guid trainingID);
    }
}
