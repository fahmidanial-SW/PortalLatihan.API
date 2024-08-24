using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Domain.Repositories
{
    public interface ITrainingDiscountGroupRepository : IBaseRepository<TrainingDiscountGroup>
    {
        Task<List<TrainingDiscountGroup>> GetListByTrainingID(Guid trainingID);
        Task Delete_ByTrainingID(Guid trainingID);
    }
}
