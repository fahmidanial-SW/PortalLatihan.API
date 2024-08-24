using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.Application.Services.Interface
{
    public interface ITrainingDiscountGroupService
    {
        Task<List<TrainingDiscountGroupListResponse>> GetListByTrainingID(Guid trainingID);
    }
}