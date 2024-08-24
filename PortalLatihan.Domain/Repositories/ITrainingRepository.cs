using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Repositories
{
    public interface ITrainingRepository : IBaseRepository<Training>
    {
        Task<List<Training>> GetListByZoneAndRegion(Guid? ZoneID, Guid? RegionID);

        Task<List<Training>> GetListByStatus(TrainingStatusEnum status);

        Task<List<Training>> GetListByUser(string user);

        Task<TrainingStatusEnum> GetStatusByID(Guid ID);
        Task<List<Training>> GetListByAvailable();
    }
}
