using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Domain.Repositories
{
    public interface ITicketRepository : IBaseRepository<Ticket>
    {
        Task<List<Ticket>> GetByStatus(TicketStatusEnum status);
        public Task<List<Ticket>> GetListByTrainingID(Guid trainingID);
        public Task<List<Ticket>> GetParticipantByParticipantID(Guid ID);
        Task<TicketStatusEnum> GetStatusByID(Guid ID);
    }
}
