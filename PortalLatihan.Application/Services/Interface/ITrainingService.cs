using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.Application.Services.Interface
{
    public interface ITrainingService
    {
        Task Add(TrainingAddRequest trainingDetailInput, string user);
        Task Approve(Guid id, string remark, string user);
        Task Delete(Guid id, string user);
        Task<TrainingDetailResponse> GetDetail(Guid id);
        Task<List<TrainingListResponse>> GetList();
        Task<List<TrainingListResponse>> GetListAvailable();
        Task<List<TrainingListResponse>> GetListByStatus(string trainingStatus);
        Task<List<TrainingListResponse>> GetListByUser(string user);
        Task Reject(Guid id, string remark, string user);
        Task Update(TrainingUpdateRequest trainingUpdateInput, string user);
    }
}