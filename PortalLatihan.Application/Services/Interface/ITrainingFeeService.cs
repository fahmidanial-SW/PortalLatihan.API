using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.Application.Services.Interface
{
    public interface ITrainingFeeService
    {
        Task<List<TrainingFeeListResponse>> GetListByTrainingID(Guid trainingID);
    }
}
