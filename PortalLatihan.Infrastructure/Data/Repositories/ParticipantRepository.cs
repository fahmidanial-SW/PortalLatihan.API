using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class ParticipantRepository(PortalLatihanDBContext context) : BaseRepository<Participant>(context), IParticipantRepository
    {
        private readonly PortalLatihanDBContext context = context;

        public async Task CheckExistByID(Guid ID)
        {
            try
            {
                var result = await context.PARTICIPANT.FindAsync(ID) ?? throw new Exception("Participant not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Participant>> GetListByTicketID(Guid ticketID)
        {
            return await context.PARTICIPANT.Where(x => x.TicketID == ticketID).ToListAsync();
        }


    }
}

