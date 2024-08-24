using PortalLatihan.Application.Services.Interface;
using PortalLatihan.Application.ViewModel;
using PortalLatihan.Domain;

namespace PortalLatihan.Application.Services
{
    public class RefZoneService(IUnitOfWork unitOfWork
        ) : IRefZoneService
    {
        public async Task<string> GetNameByID(Guid ID)
        {
            var zone = await unitOfWork.RefZone_ByID(ID);

            return zone.Name;
        }

        public async Task<List<ZoneDropdownResponse>> GetDropdownList()
        {
            try
            {
                var zoneList = await unitOfWork.RefZone_List();

                List<ZoneDropdownResponse> result = [];

                foreach (var zone in zoneList)
                {
                    var regionList = await unitOfWork.RefRegion_List_ByZoneID(zone.ID);
                    result.Add(new ZoneDropdownResponse
                    {
                        ID = zone.ID,
                        Name = zone.Name,
                        Regions = regionList.Select(x => new RegionDropdownResponse
                        {
                            ID = x.ID,
                            Name = x.Name
                        }).ToList()
                    });
                }

                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
