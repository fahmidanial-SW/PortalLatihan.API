using PortalLatihan.Application.ViewModel;

namespace PortalLatihan.Application.Services.Interface
{
    public interface IRefZoneService
    {
        Task<List<ZoneDropdownResponse>> GetDropdownList();
        Task<string> GetNameByID(Guid ID);
    }
}