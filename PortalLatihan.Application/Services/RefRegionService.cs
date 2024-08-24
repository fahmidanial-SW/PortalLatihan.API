using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Domain;

namespace PortalLatihan.Application.Services
{
    public class RefRegionService(IUnitOfWork unitOfWork
        ) : IRefRegionService
    {
        public async Task<string> GetNameByID(Guid ID)
        {
            var region = await unitOfWork.RefRegion_ByID(ID);

            return region.Name;
        }

    }
}
