using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Domain.Repositories
{
    public interface ITrainingFeeRepository : IBaseRepository<TrainingFee>
    {
        Task<List<TrainingFee>> List_ByTrainingID(Guid trainingID);
        Task Delete_ByTrainingID(Guid trainingID);
    }
}
