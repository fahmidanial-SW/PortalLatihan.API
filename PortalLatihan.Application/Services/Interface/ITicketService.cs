using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain.Enum;

namespace PortalLatihan.Application.Services.Interface
{
    public interface ITicketService
    {
        Task Add(TicketAddRequest ticketInsertInput, string user);
        Task<decimal> CalculateDiscountCode(Guid trainingID, decimal baseFee, decimal groupDiscountFee, string discountCode);
        Task<decimal> CalculateDiscountGroup(Guid trainingID, decimal baseFee, int quantity);
        Task<TicketPriceResponse> CalculatePrice(TicketPriceRequest ticketPriceRequest);
        Task Cancel(Guid ticketID, string user);
        Task<TicketDetailResponse> GetDetail(Guid ticketID);
        Task<List<TicketListResponse>> GetList();
        Task<List<TicketListResponse>> GetListByTrainingID(Guid trainingID);
        Task Paid(Guid ticketID, string user);
    }
}