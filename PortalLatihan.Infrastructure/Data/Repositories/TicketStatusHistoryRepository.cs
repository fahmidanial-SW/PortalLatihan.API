using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class TicketStatusHistoryRepository(PortalLatihanDBContext context) : BaseRepository<TicketStatusHistory>(context), ITicketStatusHistoryRepository
    {
        private readonly PortalLatihanDBContext context = context;

        public async Task<List<TicketStatusHistory>> GetListByTicketID(Guid ticketID)
        {
            return await context.TICKET_STATUS_HISTORY.Where(x => x.TicketID == ticketID).ToListAsync();
        }

    }


}
