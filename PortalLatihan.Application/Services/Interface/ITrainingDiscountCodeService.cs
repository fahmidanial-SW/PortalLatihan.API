using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.Application.Services.Interface
{
    public interface ITrainingDiscountCodeService
    {
        Task<List<TrainingDiscountCodeListResponse>> GetList();
        Task<List<TrainingDiscountCodeListResponse>> GetListByTrainingID(Guid trainingID);
    }
}