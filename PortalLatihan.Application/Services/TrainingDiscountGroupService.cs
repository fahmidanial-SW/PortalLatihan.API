using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain;

namespace PortalLatihan.Application.Services
{
    public class TrainingDiscountGroupService(IUnitOfWork unitOfWork
       ) : ITrainingDiscountGroupService
    {
        public async Task<List<TrainingDiscountGroupListResponse>> GetListByTrainingID(Guid trainingID)
        {
            try
            {
                var discountGroupList = await unitOfWork.TrainingDiscountGroup_List_ByTrainingID(trainingID);
                List<TrainingDiscountGroupListResponse> result = [];

                foreach(var discountGroup in discountGroupList)
                {
                    TrainingDiscountGroupListResponse item = new()
                    {
                        ID = discountGroup.ID,
                        MinParticipant = discountGroup.MinParticipant,
                        MaxParticipant = discountGroup.MaxParticipant,
                        Discount = discountGroup.Discount,
                        DiscountType = discountGroup.DiscountType.ToString(),
                    };

                    result.Add(item);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       
    }
}
