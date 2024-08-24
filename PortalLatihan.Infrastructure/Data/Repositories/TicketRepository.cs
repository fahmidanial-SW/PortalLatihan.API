using Microsoft.EntityFrameworkCore;
using PortalLatihan.Domain.Entities;
using PortalLatihan.Domain.Enum;
using PortalLatihan.Domain.Repositories;
using PortalLatihan.Infrastructure.Data.Context;

namespace PortalLatihan.Infrastructure.Data.Repositories
{
    public class TicketRepository(PortalLatihanDBContext context) : BaseRepository<Ticket>(context), ITicketRepository
    {
        private readonly PortalLatihanDBContext context = context;

        public async Task<TicketStatusEnum> GetStatusByID(Guid ID)
        {
            var result = await context.TICKET.FindAsync(ID);

            return result?.Status ?? throw new Exception("Ticket not found");
        }

        public async Task<List<Ticket>> GetListByTrainingID(Guid trainingID)
        {
            return await context.TICKET.Where(x => x.TrainingID == trainingID).ToListAsync();
        }

        public async Task<List<Ticket>> GetParticipantByParticipantID(Guid ID)
        {
            return await context.TICKET.Where(x => x.ID == ID).ToListAsync();
        }

        public async Task<List<Ticket>> GetByStatus(TicketStatusEnum status)
        {
            return await context.TICKET.Where(x => x.Status == status).ToListAsync();
        }

        public async Task<int> GetTotalDiscountCodeByID(Guid ticketID, string code)
        {
            var ticket = await context.TICKET.FirstOrDefaultAsync(x => x.ID == ticketID) ?? throw new Exception("Ticket not found");
            var discountCode = await context.TRAINING_DISCOUNT_CODE.FirstOrDefaultAsync(x => x.Code == code) ?? throw new Exception("Discount Code not found");
            var totalDiscountCode = await context.TICKET.Where(x => x.TrainingDiscountCodeID == discountCode.ID).CountAsync();

            return totalDiscountCode;
        }
    }
}
