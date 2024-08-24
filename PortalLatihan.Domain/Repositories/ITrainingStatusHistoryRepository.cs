using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Domain.Repositories
{
    public interface ITrainingStatusHistoryRepository : IBaseRepository<TrainingStatusHistory>
    {
        Task<List<TrainingStatusHistory>> GetListByTrainingID(Guid trainingID);
    }
}
