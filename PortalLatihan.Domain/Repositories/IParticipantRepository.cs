using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Domain.Repositories
{
    public interface IParticipantRepository : IBaseRepository<Participant>
    {
        Task<List<Participant>> GetListByTicketID(Guid ticketID);
    }
}
