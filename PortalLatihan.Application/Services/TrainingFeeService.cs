using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain;
using PortalLatihan.Domain.Entities;

namespace PortalLatihan.Application.Services
{
    public class TrainingFeeService(IUnitOfWork unitOfWork) : ITrainingFeeService
    {

        public async Task<List<TrainingFeeListResponse>> GetListByTrainingID(Guid trainingID)
        {
            try
            {
                List<TrainingFee> trainingFeeList = await unitOfWork.TrainingFee_List_ByTrainingID(trainingID);
                List<TrainingFeeListResponse> result = trainingFeeList.Select(x => new TrainingFeeListResponse
                {
                    ID = x.ID,
                    Fee = x.Fee,
                    ParticipantType = x.ParticipantType
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
