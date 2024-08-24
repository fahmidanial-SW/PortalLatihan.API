using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain;

namespace PortalLatihan.Application.Services
{
    public class TrainingDiscountCodeService(IUnitOfWork unitOfWork
       ) : ITrainingDiscountCodeService
    {

        public async Task<List<TrainingDiscountCodeListResponse>> GetList()
        {
            try
            {
                var discountCodeList = await unitOfWork.TrainingDiscountCode_List();
                List<TrainingDiscountCodeListResponse> result = discountCodeList.Select(x => new TrainingDiscountCodeListResponse
                {
                    ID = x.ID,
                    Code = x.Code,
                    DiscountType = x.DiscountType.ToString(),
                    Discount = x.Discount,
                    Quota = x.Quota,
                    TrainingID = x.TrainingID
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TrainingDiscountCodeListResponse>> GetListByTrainingID(Guid trainingID)
        {
            try
            {
                var discountCodeList = await unitOfWork.TrainingDiscountCode_List_ByTrainingID(trainingID);
                List<TrainingDiscountCodeListResponse> result = discountCodeList.Select(x => new TrainingDiscountCodeListResponse
                {
                    ID = x.ID,
                    Code = x.Code,
                    DiscountType = x.DiscountType.ToString(),
                    Discount = x.Discount,
                    Quota = x.Quota,
                    TrainingID = x.TrainingID
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
