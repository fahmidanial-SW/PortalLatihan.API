using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Domain.Repositories
{
    public interface ITicketStatusHistoryRepository : IBaseRepository<TicketStatusHistory>
    {
        Task<List<TicketStatusHistory>> GetListByTicketID(Guid ticketID);
    }
}